
var user = {
    init: function () {
        user.registerEvents();
    },
    registerEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this)
            var id = btn.data('id');
            $.ajax({
                url: "/Admin/User/ChangeStatus",
                data: { id: id },
                dataType: "json",
                type: "Post",
                success: function (res) {
                    if (res.Status_ == true) {
                        btn.text('Kích hoạt');
                    }
                    else {
                        btn.text('Khóa');
                    }
                }
            })
        });
        $('#btnSend').off('click').on('click', function (e) {
            e.preventDefault();
            user.saveData();
        });

    },
    saveData: function () {

        var username = $('#txtUserName').val();
        var password = $('#txtPassword').val();
        var name = $('#txtName').val();
        var address = $('#txtAddress').val();


        $.ajax({
            url: '/Admin/User/Add',
            type: 'POST',
            dataType: 'json',
            data: {
                UserName: username,
                password: password,
                Name: name,
                Address: address,
            },
            success: function (res) {
                if (res.status == true) {
                    window.alert('Gửi thành công');
                    $('#myModal').modal('hide');
                    user.resetForm();
                }
            }
        });
        
    },
    resetForm: function () {
        $('#txtUserName').val('');
        $('#txtPassword').val('');
        $('#txtName').val('');
        $('#txtAddress').val('');
    }
}

user.init();