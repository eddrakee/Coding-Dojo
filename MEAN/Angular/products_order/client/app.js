var app = angular.module('productApp', []);
app.factory('productFactory', ['$http', function($http){
    // $http lets us talk to our server
    var factory = {};
    var products = [];
    factory.index = function(callback){
        console.log('in factory.index');
        // callback is the function that is passed to setProducts function
        callback(products);
    }
    factory.create = function(product, callback){
        console.log('in factory.create');
        if(product.price && Number(parseFloat(product.price))==product.price){
            products.push(product);
            callback(products);
        }
    }
    factory.remove = function(id, callback){
        products.splice(id,1);
        callback(products);
    }
    factory.buy = function(data, callback){
        if(Number.isInteger(data.quantity)){
            if (products[data.id].quantity - data.quantity >0){
                products[data.id].quantity -= data.quantity;
            }else {
                products[quantity.id].quantity = 0;
            }
        }
        callback(products);
    }

    return factory;
}]);



// ------CONTROLLERS GOES BELOW--------

app.controller('productController', ['$scope', 'productFactory', function($scope, productFactory){
    // setProducts will update with information from factory.create
    function setProducts(data){
        $scope.products = data;
        $scope.product = {};
    }

    $scope.products = {};
    $scope.product = {};

    $scope.index = function(){
        console.log('in controller index');
        productFactory.index(setProducts);
    }

    $scope.index();

    $scope.create = function(){
        console.log('in controller create');
        productFactory.create($scope.product, setProducts);
    }
    $scope.remove = function(id){
        console.log('in controller remove');
        productFactory.remove(id, setProducts);
    }
}]);

app.controller('orderController', ['$scope', 'orderFactory', function($scope, productFactory){
    function($scope, productFactory){
        function setProducts(data){
            $scope.products = data;
            $scope.product = {};
        }
        $scope.products = [];

        productFactory.index(setProducts);
        $scope.update = function(id){
            productFactory.update({
                id: id,
                quantity: product.quantity
            }, setProducts)
        }
    }

}])