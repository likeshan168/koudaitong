function MyOrderViewModel() {
    var self = this;

    //self.showInput = ko.observable(false);//更具选择的条件不同显示不同的输入框

    //self.showSelect = ko.observable(false);//显示状态选择框用的

    //self.showDate = ko.observable(true);//显示时间输入框

    self.searchT = ko.observable();//查询条件
    self.status = ko.observable();//状态
    self.startDate = ko.observable();//开始时间
    self.endDate = ko.observable();//结束时间
    self.nickname = ko.observable();//昵称

    //self.searchV = ko.observable();

    //改变查询条件
    self.sltChg = function (data, event) {
        //var obj = $(event.target);
        //console.log(obj.val());
        //if (obj.val() === "1" || obj.val() === "2") {//时间
        //    self.showDate(true);
        //    self.showInput(false);
        //    self.showSelect(false);
        //} else if (obj.val() === "3") {//状态
        //    self.showInput(false);
        //    self.showSelect(true);
        //    self.showDate(false);
        //} else {//昵称
        //    self.showInput(true);
        //    self.showSelect(false);
        //    self.showDate(false);
        //}
        
    }

    //ajax 请求之前
    self.showRequest = function (formData, jqForm, options) {
        $("#loadmodal").modal("show", { backdrop: 'static' });
        return true;
    }
    //ajax 请求之后
    self.showResponse = function (responseText, statusText) {
        $("#loadmodal").modal("hide");
        //alert(responseText);
        console.log(responseText);
        //window.location.reload();
        
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
    self.submitFrm = function (data, event) {
        event.preventDefault();
        //验证
        //if (self.searchT() === "4") {
        //    if (self.nickname() === "") {
        //        alert("昵称不能为空");
        //        return;
        //    }
        //    self.searchV(self.nickname());
        //} else if (self.searchT() === "3") {
        //    self.searchV(self.status());
        //}
        //提交数据
        self.options.data = {
            searchT: self.searchT(),
            startDate: self.startDate(),
            endDate: self.endDate(),
            nickName: self.nickname(),
            status:self.status()
        };

        $("#frm").ajaxSubmit(self.options);

    }
}


ko.applyBindings(new MyOrderViewModel());