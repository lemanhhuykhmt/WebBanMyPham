var cart = {
    init: function () {
        cart.regEvents();
    },

    regEvents: function () {
        $('#btnUpdate').off('click').on('click', function () {
            var listTextBox = $('.txtQuantity');
            var cartList = [];
            $.each(listTextBox, function (i, item) {
                cartList.push({
                    Quantity: $(item).val(),
                    Product: {
                        ProductID: $(item).data('id')
                    }
                });
            });


            $.ajax({
                url: '/Cart/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res){
                    if (res.status == true) {
                        window.location.href = "/Cart/Index";
                    }
                }
            });
        });
    }
}

cart.init();