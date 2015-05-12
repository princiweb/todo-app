(function () {
  'use strict';

  angular
    .module('app.autenticacao')
    .controller('Autenticar', Autenticar);
    
  function Autenticar(autenticacaoService) {
    var vm = this;
    
    vm.enviar = function(ehValido) {
      
      autenticacaoService.autenticar(vm.email, vm.senha)
         .then(function (result) {
           
           console.log(result);
           
         }, function(err) {
           
           console.log(err);
           
         });
    
    };
  }

}());