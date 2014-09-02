/// <reference path="../knockout-3.1.0.debug.js" />
///hello wolrd

function MyTestViewModel() {
    var self = this;

    self.htmlStr = [];//拼接html串用的


    self.pcid = ko.observable();//父类别id
    self.subCategories = ko.observableArray();//子类数组

    self.cid = ko.observable();//类别id
    self.promotion_cid = ko.observable();//商品推广栏目id
    self.tag_ids = ko.observable();//商品标签

    self.price = ko.observable();//商品价格
    self.title = ko.observable("");//商品标题
    self.desc = ko.observable("");//商品描述
    self.is_virtual = ko.observable(0);//是否是虚拟商品
    self.post_fee = ko.observable(0.00);//运费
    self.sku_properties = ko.observable("");//sku的属性
    self.sku_quantities = ko.observable("");//Sku的数量串
    self.sku_prices = ko.observable("");//Sku的价格串
    self.sku_outer_ids = ko.observable("");//Sku的商家编码
    self.origin_price = ko.observable("");//原价
    self.buy_url = ko.observable("");//该商品的外部购买地址
    self.outer_id = ko.observable("");//商品货号
    self.buy_quota = ko.observable(0);//每人限购多少件
    //self.quantity = ko.observable();//商品总库存
    self.hide_quantity = ko.observable(0);//是否隐藏商品库存
    //self.fields = ko.observable("");//需要返回的商品对象字段


    self.files = ko.observable();//用于判断文件是否为空用的

    self.ckbs = $("#tb_details").find('input:checkbox');//获取所有的checkbox



    //self.selectedSub = ko.observableArray([{ value: '3000004', name: '童装' }]);//3000004

    //选择改变子类
    self.selectCategory = function (data, event) {
        self.pcid($(event.target).val());
        console.log(self.pcid());
        self.getSub();
    }
    //初始化商品类别下拉框
    self.init = function () {
        self.pcid($("#parent_categories").val());
        self.getSub();
        self.price(self.getUrlParam('price'));
        self.title((self.getUrlParam("name")));

        //console.log(self.selectedSub());

    }
    //获取子类
    self.getSub = function () {
        $.post("/product/getsub", { pcid: self.pcid() }, function (data) {
            self.htmlStr = [];
            $.each(data, function (index, value) {
                //self.htmlStr.push("<option value='" + value.pcid + "'>" + value.name + "</option>");
                self.htmlStr.push({ value: value.cid, name: value.name });
            });

            //$("#sub_categories").html(self.htmlStr.join(''));
            self.subCategories(self.htmlStr);
            self.cid('3000004');

        });
    }
    //获取url传递过来的参数
    self.getUrlParam = function (name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
        var r = window.location.search.substr(1).match(reg);  //匹配目标参数
        //if (r != null) return unescape(r[2]); return null; //返回参数值
        if (r != null) return decodeURIComponent(r[2]); return null; //返回参数值
    };
    //调用初始化函数
    self.init();

    //全选事件(类函数)
    MyTestViewModel.selectAll = function (obj) {
        var bj = $(obj), ckbs = self.ckbs;

        $.each(ckbs, function (index, ckb) {
            $(ckb).prop("checked", bj.prop('checked'));
        });

        self.calculate();
    }

    //颜色:黄色;尺寸:M,颜色:黄色;尺寸:S  
    //Sku的数量串。结构如：num1,num2,num3 如：2,3。无Sku则为空
    //Sku的价格串。结构如：10.00,5.00,... 精确到2位小数。单位:元。无Sku则为空
    //Sku的商家编码（商家为Sku设置的外部编号）串。结构如：1234,1342,... 

    //获取选中的值，拼接成字符串数据，准备上传

    self.style_color_size = "";//为记录上传时间而特意设定的
    self.calculate = function () {
        var color = "", nums = "", prices = "", ids = "";
        self.style_color_size = "";
        //注意还包含了第一个按钮，要去除掉
        $.each(self.ckbs, function (index, ckb) {
            //颜色
            if (index !== 0 && $(ckb).is(":checked")) {
                //记录上传时间用的
                self.style_color_size += $(ckb).data("style") + "@" + $(ckb).data("col_no") + "@" + $(ckb).data("size") + ",";

                color += "颜色:" + $(ckb).data("color") + ";尺寸:" + $(ckb).data("size") + ",";

                nums += parseInt($(ckb).data("num")) + ",";
                prices += parseFloat($(ckb).data("price")).toFixed(2) + ",";
                ids += $(ckb).data("style_no") + ",";
            }

        });
        self.sku_properties(color.substr(0, color.length - 1));
        self.sku_quantities(nums.substr(0, nums.length - 1));
        self.sku_prices(prices.substr(0, prices.length - 1));
        self.sku_outer_ids(ids.substr(0, ids.length - 1));
        self.style_color_size = self.style_color_size.substr(0, self.style_color_size.length - 1);
        return true;
    }



    //ajax 请求之前
    self.showRequest = function (formData, jqForm, options) {
        $("#loadmodal").modal({ show: true, backdrop: 'static' });
        return true;
    }
    //ajax 请求之后
    self.showResponse = function (responseText, statusText) {
        $("#loadmodal").modal("hide");
        //alert(responseText);

        if (responseText.indexOf("成功") >= 0) {
            alert(responseText);
            window.location.reload();
        } else {
            alert(responseText);
        }


    }
    //ajax 请求的参数
    self.options = {
        beforeSubmit: self.showRequest,  // pre-submit callback
        success: self.showResponse,  // post-submit callback
        //url: '/report/search/',         // override for form's
        timeout: 400000
        //type: 'post'        // 'get' or 'post', override
    };
    //提交表单
    self.uploadData = function (data, event) {
        event.preventDefault();
        if (self.tag_ids() === undefined) {
            alert("请选择商品标签");
        }
        else if (self.title().length === 0) {
            alert("请输入商品标题");

        } else if (self.desc().length < 5) {
            alert("商品描述太短");
        }
        else if (parseFloat(self.price()) < 0.01 || parseFloat(self.price()) > 100000000) {
            alert("商品价格不符合要求");
        }
        else if (self.files() === undefined) {
            alert("请选择图片");
        }
        else {
            self.options.data = {
                cid: self.cid(),//类别id
                promotion_cid: self.promotion_cid(),//商品推广栏目id
                tag_ids: self.tag_ids(),//商品标签
                title: self.title(),//商品标题
                price: self.price(),//商品价格
                desc: self.desc(),//商品描述
                is_virtual: self.is_virtual(),//是否是虚拟商品
                post_fee: self.post_fee(),//运费
                sku_properties: self.sku_properties(),//sku的属性
                sku_quantities: self.sku_quantities(),//Sku的数量串
                sku_prices: self.sku_prices(),//Sku的价格串
                sku_outer_ids: self.sku_outer_ids(),//Sku的商家编码
                origin_price: self.origin_price(),//原价
                buy_url: self.buy_url(),//该商品的外部购买地址
                outer_id: self.outer_id(),//商品货号
                buy_quota: self.buy_quota(),//每人限购多少件
                hide_quantity: self.hide_quantity(),//是否隐藏商品库存

                style_color_size: self.style_color_size//只为记录用的（就是记录上传的时间）
            };

            //console.log(self.options.data);
            $("#frm_item").ajaxSubmit(self.options);
        }
    }
    //获取url传递过来的参数

    //加载商品分类以及其推广栏目
    //self.loadCategory = function (data,event) {
    //    $.get("/product/category", function (data) {
    //        console.log(data);
    //        $(event.target).html(data);
    //    });
    //}

}

ko.applyBindings(new MyTestViewModel());

//$("#div_category").load("/product/category");



