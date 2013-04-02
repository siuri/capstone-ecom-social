function CartViewModel() {
    var self = this;
    self.shops = ko.observableArray([]);
    self.addProduct = function (product) {
        if (product instanceof ProductModel) {
            if (product.shopId != -1) {
                self.shops().forEach(function (shop) {
                    if (shop.shopId == product.shopId) {
                        var checkIfExistProduct = 0;
                        var pro
                        shop.products().forEach(function (p) {
                            if (product.productId == p.productId) {
                                checkIfExistProduct++;
                                p.productQuantity(p.productQuantity() + product.productQuantity());
                            }
                        })
                        if (checkIfExistProduct == 0) {
                            shop.products.push(product);
                        }
                    }
                    self.saveToStorage();
                    return;
                })
            }
        }
    }
    self.checkShop = function (shop) {
        var i = 0;
        self.shops().forEach(function (sh) {
            if (sh.shopId == shop.shopId) {
                i++;
                return
            }
        })
        if (i == 0) {
            self.shops.push(shop);
        }
    }
    self.saveToStorage = function () {
        var dummyCart = []
        self.shops().forEach(function (s) {
            var shop = [];
            shop.push(s.shopId);
            shop.push(s.storeTitle);

            s.products().forEach(function (p) {
                var product = [];
                product.push(p.productId);
                product.push(p.productTitle);
                product.push(p.productImage);
                product.push(p.productPrice);
                product.push(p.productQuantity());

                shop.push(product)
            })
            dummyCart.push(shop);
        })
        var json = JSON.stringify(dummyCart);
        localStorage.setItem("sb_cartData", json);
    }
    self.loadFromStorage = function () {
        var json = localStorage.getItem("sb_cartData");
        if (json == null) return;
        var dataObject = JSON.parse(json);
        dataObject.forEach(function (s) {
            var shop = new ShopModel(s[1], s[0])
            for (var i = 2; i < s.length; i++) {
                shop.products.push(new ProductModel(s[i][1], s[i][2], s[i][3], s[i][4], s[i][0], s[0]));
            }
            //s[2].forEach(function(p){
            //    shop.products.push(new ProductModel(p[1], p[2], p[3],p[4],p[0],s[0]));
            //})
            cartmodel.shops.push(shop)
        })
    }
}
function ShopModel(title, shopId) {
    var self = this;
    self.shopId = typeof shopId == "undefined" ? -1 : shopId;
    self.storeTitle = title;
    self.checkoutLink = "/Order/Checkout?sid=" + self.shopId;
    self.products = ko.observableArray([])
    self.isCheckoutshop = ko.computed(function () {
        var regrs = location.search.match(/[?&]sid=(\d)[&$]?/);
        if (regrs !=null && regrs.length > 1) {
            var sid = parseInt(regrs[1]);
            if (sid == self.shopId) return true;
        }
        return false;
    })
    self.removeProduct = function (product, $root) {
        self.products.remove(product);
        if (self.products().length == 0) {
            $root.shops.remove(self);
        }
        $root.saveToStorage();
    }
}
function ProductModel(title, image, price, quantity, productId, shopId) {
    var self = this;
    self.productId = typeof productId == "undefined" ? -1 : productId;
    self.shopId = typeof shopId == "undefined" ? -1 : shopId;

    self.productTitle = title;
    self.productImage = image;
    self.productPrice = price;
    self.productQuantity = ko.observable(quantity);
}

var cartmodel = new CartViewModel();
cartmodel.loadFromStorage();
$(function () {
    ko.applyBindings(cartmodel);
    
})