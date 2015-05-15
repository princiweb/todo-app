(function () {
  'use strict';

  angular
    .module('app.autenticacao')
    .factory('autenticacaoService', autenticacaoService);
    
  function autenticacaoService($http, $q, localStorageService) {
		
		var service = {
      autenticar: autenticar,
			sair: sair
    };
		
		return service;
    
		function autenticar(email, senha) {
			
			var credenciais = 'grant_type=password&username=' + email + '&password=' + senha;
			var deferred = $q.defer();
			
			$http.post('http://todo-app.gear.host/api/token', credenciais, {
        headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
      }).success(function(data) {
				
				var token = data.access_token;
				
				localStorageService.set('autorizacao', { token: token });
				
				deferred.resolve({
					nome: 'Rodolfo Pereira'
				});
				
			}).error(function(err) {
				sair();
				
				deferred.reject(err);
				
			});
			
			return deferred.promise;			
		}
		
		function sair() {
      localStorageService.remove('autorizacao');
    }
		
  }

}());