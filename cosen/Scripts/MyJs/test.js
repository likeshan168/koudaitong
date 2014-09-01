/// <reference path="../knockout-3.1.0.debug.js" />
function MyTestViewModel() {
    var self = this;
    self.cid = ko.observable();
    //self.parent_cid = ko.observable("");
    self.htmlStr = [];
    self.sltchg = function (data,event) {
        self.cid($(event.target).val());
        console.log(self.cid());
        //self.parent_cid(self.parent_cid() +"-"+ $(event.target).children(":selected").data("parent_cid"));
        self.getSub();
    }

    self.init = function () {
        self.cid($("#parent_categories").val());
        self.getSub();
    }

    self.getSub = function () {
        $.post("/test/getsub", { cid: self.cid() }, function (data) {
            self.htmlStr = [];
            $.each(data, function (index, value) {
                self.htmlStr.push("<option value='"+value.cid+"'>"+value.name+"</option>");
            });

            $("#sub_categories").html(self.htmlStr.join(''));
        });
    }

    self.init();
}

ko.applyBindings(new MyTestViewModel());