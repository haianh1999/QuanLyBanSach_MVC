var user = {
    init: function () {
        user.registerEvents();
    },
    registerEvent: function {
        $(document).ready(function () {
            user.resetForm();
        });
    },

    resetForm: function () {
        $('#txtUserName').val('');
       
    }


}
user.init();