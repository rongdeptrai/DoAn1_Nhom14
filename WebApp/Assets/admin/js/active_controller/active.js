var cus = {
    inint: function () {
        cus.registerEvents();
    },
    registerEvents: function () {
        $('.btn-active').off('click').on('click',
            function (e) {
                e.preventDefault();
                var btn = $(this);
                var id = btn.data('id');
                $.ajax({
                    url: "/Admin/Customer/ChangeStatus",
                    data: { id:id },
                    datatype: "json",
                    type:"POST",
                    success: function(response) {
                                console.log(response);
                                if (response.status == true) {
                                    btn.text('Active');
                                    btn.removeClass('btn-danger');
                                    btn.addClass('btn-success');
                                }
                                else {
                                    btn.text('Blocked');
                                    btn.removeClass('btn-success');
                                    btn.addClass('btn-danger');
                                }
                            }
                });
            });
    }
}
cus.inint()