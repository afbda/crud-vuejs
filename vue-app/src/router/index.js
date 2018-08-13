import Vue from 'vue'
import Router from 'vue-router'
import Clientes from '@/components/Clientes'
import FormCliente from '@/components/FormCliente'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Clientes',
      component: Clientes
    },
    {
      path: '/novo',
      name: 'Novo Cliente',
      component: FormCliente
    },
    {
      path: '/editar/:id',
      name: 'Editar Cliente',
      component: FormCliente
    }
  ]
})
