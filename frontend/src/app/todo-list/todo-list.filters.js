(function () {
  'use strict';

  angular
    .module('app.todo-list')
    .filter('fromNow', fromNow)
    .filter('status', status);
		
	function fromNow() {
		
		return function(data) {
			moment.locale('pt-BR');
			
			return moment(data).fromNow();
		}
		
	}
	
	function status() {
		
		return function(listaTarefas, search) {
			var novaLista = [];
			
			if (!search)
				return listaTarefas;
			
			for (var i = 0; i < listaTarefas.length; i++) {
				
				if (search.Pendente && listaTarefas[i].Status === 1) {
					novaLista.push(listaTarefas[i]);
					
					continue;
				}
				
				if (search.Finalizado && listaTarefas[i].Status === 2) {
					novaLista.push(listaTarefas[i]);
				}
				
			}
			
			return novaLista;
		}
		
	}

}());