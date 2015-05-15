(function () {
  'use strict';

  angular
    .module('app.autenticacao')
    .controller('Autenticar', Autenticar);
    
  function Autenticar($location, autenticacaoService) {
    var vm = this;
    
    
    vm.enviar = function(ehValido) {
      
      if (!ehValido)
        return false;
      
      autenticacaoService.autenticar(vm.email, vm.senha)
         .then(function (result) {
           
          $location.path('/todo-list.html');
           
         }, function(err) {
           
           vm.erro = err.error_description;
           
         });
    
    };
  }

}());