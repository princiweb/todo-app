(function () {
  'use strict';

  angular
		.module('app.core')
		.config(configRoutes);
    
  function configRoutes($routeProvider) {
    $routeProvider			
      .when('/', {
          templateUrl: 'app/autenticacao/autenticar.html',
          controller: 'Autenticar',
          controllerAs: 'vm'
      });
  } 

}());