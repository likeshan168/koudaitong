/// <reference path="../knockout-3.1.0.debug.js" />


//模型
function MyProductViewModel() {
    var self = this;
    self.pageArr = ko.observableArray();//初始化页码
    self.currentPage = ko.observable(1);//当前页
    self.activeCls = ko.observable(self.currentPage());//选中页码时样式
    self.oldPage = ko.observable();//改变之前的页
    self.totalPage = ko.observable(parseInt($("#totalPage").text()));//总页数


    self.beishu = ko.observable(0);//5 的倍数 
    self.tmpArr = [];


    //先判断总页数，然后再初始化页码
    self.init = function () {
        console.log(self.totalPage());
        if (self.totalPage() > 0 && self.totalPage() <= 5) {
            for (var i = 1; i <= self.totalPage() ; i++) {
                self.pageArr.push(i);
            }
        } else if (self.totalPage() > 5) {
            self.pageArr([1, 2, 3, 4, 5]);
        } else {
            self.pageArr([]);
        }
    }

    self.init();

    //下一页
    self.nextPage = function () {

        console.log(self.currentPage());
        console.log(self.totalPage());
        if (self.currentPage() < self.totalPage()) {
            if (self.currentPage() % 5 === 0) {
                self.tmpArr = [];

                if (self.currentPage() + 5 < self.totalPage()) {
                    $.each(self.pageArr(), function (index, value) {
                        self.tmpArr.push(value + 5);
                    });
                } else {
                    $.each(self.pageArr(), function (index, value) {
                        if (value + 5 > self.totalPage()) {
                            return;
                        } else {
                            self.tmpArr.push(value + 5);
                        }

                    });
                }


                self.pageArr(self.tmpArr);
                self.beishu(self.beishu() + 1);
            }
            //console.log(self.currentPage());
            self.currentPage(parseInt(self.currentPage()) + 1);//页码移动到下一位
            self.activeCls(self.currentPage());

            self.search();
        }



    };
    //上一页
    self.prevPage = function () {
        if (self.currentPage() > 1) {//页数大于1
            if ((self.currentPage() - 1) % 5 === 0) {//上一页还能被5整除
                self.tmpArr = [];

                if (self.tmpArr.length === 5) {//刚好是5个
                    $.each(self.pageArr(), function (index, value) {
                        self.tmpArr.push(value - 5);
                    });

                }
                else {//不足5个的情况
                    var tmp = self.pageArr()[0];
                    for (var i = 5; i >= 1; i--) {
                        self.tmpArr.push(tmp - i);
                    }

                }
                self.pageArr(self.tmpArr);
                self.beishu(self.beishu() - 1);
            }
            self.currentPage(parseInt(self.currentPage()) - 1);
            self.activeCls(self.currentPage());
            self.search();

        }
    }
    //选择页码
    self.selectPage = function (data, event) {
        //console.log(data);
        self.currentPage(data);
        self.activeCls(self.currentPage());
        self.search();
    }
    //输入页码
    self.writePage = function () {
        if (self.currentPage() < 0 || self.currentPage() > self.totalPage()) {
            alert("输入的数字不合法");
            self.currentPage(self.oldPage());//恢复原来的值

        } else {
            var zc = parseInt(self.currentPage() / 5);//正除
            var cy = self.currentPage() % 5;//除余
            var tmp;
            if (parseInt(self.currentPage()) === 5) {
                self.pageArr([1, 2, 3, 4, 5]);

                self.beishu(0);
            }
            if (self.currentPage() > 5) {//还有一种情况就是刚好整除的情况

                self.tmpArr = [];
                var min = self.pageArr()[0], max = self.pageArr()[self.pageArr().length - 1];
                if (cy > 0) {
                    $.each(self.pageArr(), function (index, value) {
                        tmp = value + (zc - self.beishu()) * 5;
                        if (tmp <= self.totalPage()) {
                            self.tmpArr.push(tmp);
                        } else {
                            return;
                        }

                    });
                } else {

                    if (self.currentPage() > max) {
                        zc = zc - 1;

                        $.each(self.pageArr(), function (index, value) {
                            tmp = value + (zc - self.beishu()) * 5;

                            self.tmpArr.push(tmp);
                        });
                    } else if (self.currentPage() < min) {
                        zc = zc - 1;
                        $.each(self.pageArr(), function (index, value) {
                            tmp = value + (zc - self.beishu()) * 5;
                            self.tmpArr.push(tmp);
                        });
                    }
                }
                self.pageArr(self.tmpArr);

                self.beishu(zc);
            }

            self.activeCls(self.currentPage());
            self.search();
        }

    }
    //读取页码改变之前的值
    self.currentPage.subscribe(function (oldvalue) {
        self.oldPage(oldvalue);
    }, null, "beforeChange");

    //查询数据
    self.search = function () {
        $("#loadmodal").modal("show");
        $.post("/product/search", { searchT: $("#searchT").val(), searchV: $("#searchV").val(), page: self.currentPage() }, function (data) {
            self.tmpArr = [];
            //console.log(data);
            $.each(data, function (index, value) {
                self.tmpArr.push("<tr data-bind='event:{dbclick:showDetails}'><td>" + value.row_num + "</td>");
                self.tmpArr.push("<td>" + value.sty_no + "</td>");
                self.tmpArr.push("<td>" + value.com_nm + "</td>");
                self.tmpArr.push("<td>" + value.kucun + "</td>");
                self.tmpArr.push("<td>" + value.unt_pr + "</td>");

                self.tmpArr.push("<td><button onclick='showDetails(this);' data-style_no='"+value.sty_no+"' data-price='"+value.unt_pr+"'  class='btn btn-default'>明细</button></td></tr>");
            });

            $("#tbinfo").html(self.tmpArr.join(''));

            //console.log(self.tmpArr.join(''));
            $("#loadmodal").modal("hide");
        });
    }
    //改变查询条件
    self.sltchg = function () {
        $("#searchV").val('');
    }


    MyProductViewModel.searchDetails = function (style_no,price) {
        //alert(style_no);
        window.open('/product/details?styleNo=' + style_no+'&price='+price, "_blank");
    };





}
function showDetails(obj) {
    MyProductViewModel.searchDetails($(obj).data("style_no"),$(obj).data("price"));
}

ko.applyBindings(new MyProductViewModel());

