var app = angular.module('productApp', []);


app.factory('productFactory', ['$http', function($http){
    // $http lets us talk to our server
    var factory = {};
    var products = [{name:'Carrot', price:4.32, quantity:4}];
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
        if (data.quantity > 0){
        data.quantity -= 1;
        }
        else{
            return;
        }
        callback(products);
    };

    return factory;
}]);



// ------CONTROLLERS GOES BELOW--------

app.controller('productController', ['$scope', 'productFactory', function($scope, productFactory){
    // setProducts will update with information from factory.create
    function setProducts(data){
        $scope.products = data;
        $scope.product = {};
    }

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

app.controller('orderController', ['$scope', 'productFactory', function($scope, productFactory){
        function setProducts(data){
            console.log('in Orders setProducts');
            $scope.products = data;
            $scope.product = {};
        }
        
        $scope.products = [];
        $scope.product={};

        $scope.index = function(){
            console.log('in Order index');
            productFactory.index(setProducts);
        }
        $scope.index();

        $scope.buy = function(product){
            console.log('in Orders buy');
            productFactory.buy(product, setProducts)
        }
    }]);