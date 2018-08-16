<template>
    <div class="row">
        <div class="col-12">
            <h1>Cliente</h1>
            <label class="mr-sm-2">CPF</label>
            <input required v-model="cliente.cpf" class="mr-sm-3">
            <label class="mr-sm-2">Nome</label>
            <input required v-model="cliente.nome" class="mr-sm-3">
            <label class="mr-sm-2">Email</label>
            <input required v-model="cliente.email" class="mr-sm-3">
            <b-button variant="success" @click="salvar">Salvar</b-button>
            <h2>Telefones</h2>
            <b-button variant="primary" @click="novoTelefone=true">Adicionar telefone</b-button>
            <div v-if="novoTelefone">
                <label>Telefone</label>
                <input type="number" required v-model="telefone.telefone">
                <b-button variant="success" @click="adicionarTelefone">Salvar telefone</b-button>
                <b-button variant="danger" @click="novoTelefone=false">Cancelar</b-button>
            </div>
            <p v-if="cliente.telefones == undefined || cliente.telefones.length == 0">Nenhum telefone encontrado.</p>
            <table v-else class="table">
                <tr>
                    <th>Telefone</th>
                    <th></th>
                </tr>
                <tr v-for="item in cliente.telefones" v-bind:key="item.id" v-bind:item="item.telefone">
                    <td>{{item.telefone}}</td>
                    <td>
                        <b-button size="sm" @click="excluirTelefone(item)" class="mr-2" variant="danger">
                            Excluir
                        </b-button>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</template>

<script>
import Axios from 'axios'
export default {
  methods: {
    buscarCliente: function (id) {
      Axios.get('http://localhost:51401/api/clientes/' + id)
      .then((retorno) => {
        console.log(retorno)
        if (retorno.data === '') {
          this.$swal({
            type: 'error',
            title: 'Oops...',
            text: 'Nenhum usuário encontrado'
          })
          this.$router.replace('/')
        }
        this.cliente = retorno.data
      })
    },
    adicionarTelefone: function () {
      if (this.cliente.telefones === undefined) {
        this.cliente.telefones = []
      }
      this.cliente.telefones.push(this.telefone)
      this.telefone = {}
      this.novoTelefone = false
    },
    excluirTelefone: function (telefone) {
      var index = this.cliente.telefones.indexOf(telefone)
      if (index > -1) {
        this.cliente.telefones.splice(index, 1)
        console.log(this.cliente.telefones)
      }
      if (telefone.id !== undefined) {
        Axios.delete('http://localhost:51401/api/telefones/' + telefone.id)
      }
    },
    salvar: function () {
      if (!this.cliente.cpf || !this.cliente.nome || !this.cliente.email) {
        this.$swal('Todos os campos são obrigatórios')
        return
      }
      if (this.cliente.telefones === undefined || this.cliente.telefones.length === 0) {
        this.$swal('É necessário ao menos um telefone cadastrado')
        return
      }
      this.cliente.situacao = true
      if (this.$route.params.id !== undefined) {
        console.log(this.cliente)
        Axios.put('http://localhost:51401/api/clientes/', this.cliente).then(() => {
          this.$router.go(-1)
        })
      } else {
        Axios.post('http://localhost:51401/api/clientes/', this.cliente).then(() => {
          this.$router.go(-1)
        })
      }
    }
  },
  created () {
    if (this.$route.params.id !== undefined) {
      this.buscarCliente(this.$route.params.id)
    }
  },
  data () {
    return {
      cliente: {},
      novoTelefone: false,
      telefone: {}
    }
  }
}
</script>
