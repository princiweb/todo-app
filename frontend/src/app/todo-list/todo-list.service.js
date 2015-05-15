(function () {
  'use strict';

  angular
    .module('app.todo-list')
    .factory('todoListService', todoListService);
    
  function todoListService($http) {
		
		var service = {
      inserir: inserir,
      finalizar: finalizar,
      obterTodas: obterTodas
    };
		
		return service;
    
    function inserir(titulo) {
      var tarefa = {
        titulo: titulo
      };
      	
			return $http.post('http://todo-app.gear.host/api/usuarios/me/tarefas', tarefa);
		}
    
    function finalizar(id, status) {
      var tarefa = {
        Status: status,
      };
      	
			return $http.put('http://todo-app.gear.host/api/usuarios/me/tarefas/' + id, tarefa);
		}
    
		function obterTodas() {
			return $http.get('http://todo-app.gear.host/api/usuarios/me/tarefas');
		}
		
  }

}());