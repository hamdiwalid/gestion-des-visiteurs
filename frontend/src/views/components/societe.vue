<template>
  <div class="card mb-4">
    <div class="card-header pb-0">
      <h6>Sociétes</h6>
      <button @click="toggleModal" type="button" id="btn1" class="btn btn-success mb-4">+</button>
      <div class="row">
    <div class=" col-xl-4 col-lg-5 col-md-6 d-flex flex-column">
      <input
                      id="search"
                      type="string"
                      placeholder="Recherche"
                      class="form-control col-6"
                      name="search"
                      v-model="search"
                    />
                    </div>
                    </div>
    </div>
    <div class="card-body px-0 pt-0 pb-2">
      <div class="table-responsive p-0">
        <table class="table align-items-center mb-0">
          <thead>
            <tr>
              <th
                class="text-center text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"
              >
                Nom
              </th>
              <th
                class="text-center text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"
              >
                Description
              </th>
              <th
                class="text-center text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"
              >
                Matricule fiscal
              </th>
              <th
                class="text-center text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"
              >Action</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="societe in filteredItems" :key="societe.id">
              <td class="align-middle text-center">
                {{societe.nom}}
              </td>
              <td class="align-middle text-center">
                 {{societe.description}}
              </td>
              <td class="align-middle text-center">
                {{societe.matricule}}
              </td>
              <td class="align-middle text-center">
                <div class="ms-auto text-end">
            <a @click="sup(societe.id)"
              class="btn btn-link text-danger text-gradient px-3 mb-0"
              href="javascript:;"
            >
              <i class="far fa-trash-alt me-2" aria-hidden="true"></i>Supprimer
            </a>
            <router-link :to="`/modifiersociete/${societe.id}`">
            <a class="btn btn-link text-dark px-3 mb-0" href="javascript:;">
              <i class="fas fa-pencil-alt text-dark me-2" aria-hidden="true"></i
              >Modifier
            </a>
            </router-link>
          </div>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
   <ModalC @close="toggleModal" :modalActive="modalActive">
      <div class="modal-content">
        <h4>Ajouter sociéte</h4>
        <form role="form" @submit.stop.prevent="ajouter" class="text-start">
                    <label>Nom</label>
                    <input
                      id="nom"
                      type="string"
                      placeholder="Nom"
                      class="form-control"
                      name="nom"
                      v-model="nom"
                    />
                    <label>Description</label>
                    <textarea id="description"
                      type="string"
                      placeholder="Description"
                      class="form-control"
                      name="description"
                      v-model="description"
                      />
                      <label>Matricule fiscal</label>
                    <input
                      id="matricule"
                      type="string"
                      placeholder="Matricule fiscal"
                      class="form-control"
                      name="matricule"
                      v-model="matricule"
                    />
                    <div class="text-center">
                      <vsud-button
                        class="btn btn-success mb-4"
                        variant="gradient"
                        color="success"
                        id="btn2"
                        >Ajouter
                      </vsud-button>
                    </div>
                    <p id="p" v-if="errors.length">
                        <b>Veuillez corriger les erreurs suivantes:</b>
                        <ul>
                        <li v-for="error in errors " :key="error">{{ error }}</li>
                        </ul>
                    </p>
                  </form>
      </div>
    </ModalC>
</template>

<script>
import axios from 'axios';
import ModalC from "./ModalC.vue";
import { ref } from "vue";
import VsudButton from "@/components/VsudButton.vue";
export default {
  name: "societe",
  data() {
    return {
      societes:null,
      nom:'',
      description:'',
      matricule:'',
      errors: [],
      search:"",
      table:[],
      errors1: [],
      societesid:{},
    };
  },
  components: {
    ModalC,
    VsudButton
  },
  setup() {
    const modalActive = ref(false);
    const toggleModal = () => {
      modalActive.value = !modalActive.value;
    };
    const modalActive1 = ref(false);
    const toggleModal1 = () => {
      modalActive1.value = !modalActive1.value;
    };
    return { modalActive, toggleModal, modalActive1, toggleModal1 };
  },
  async created(){
      axios.get('Societe')
      .then(reponse=>{
         this.societes = reponse.data;
         for (let i = 0; i < this.societes.length; i++) {
           this.table.push(this.societes[i]);
         }
      })
  },
  computed: {
    filteredItems() {
      return  this.table.filter((item) => {
        return item.nom.toLowerCase().includes(this.search.toLowerCase());
      });
    },
  },
  methods:{
    ajouter: function (e) {
      if (this.nom && this.matricule) {
      axios.post('Societe',{
        nom:this.nom,
        description:this.description,
        matricule:this.matricule
      })
      .then(reponse=>{
        axios.get('Societe')
      .then(reponse=>{
         this.societes = reponse.data;
      })
        console.log(reponse)
        location.reload()
      })
      }
      this.errors = [];

      if (!this.nom) {
        this.errors.push('Nom est obligatoire.');
      }
      if (!this.matricule) {
        this.errors.push('Matricule est obligatoire.');
      }

      e.preventDefault();
    },
    sup(id){
      axios.delete(`Societe?id=${id}`)
      .then(reponse=>{
        axios.get('Societe')
      .then(reponse=>{
         this.societes = reponse.data;
      })
        console.log(reponse)
      })
    },
    modifier(id,nom,description,matricule){
      if (nom && matricule) {
      axios.put(`Societe?id=${id}`,{
        nom:nom,
        description:description,
        matricule:matricule
      })
      .then(reponse=>{
        axios.get('Societe')
      .then(reponse=>{
         this.societes = reponse.data;
      })
        console.log(reponse)
        location.reload()
      })
      }
      this.errors1 = [];

      if (!nom) {
        this.errors1.push('Nom est obligatoire.');
      }
      if (!matricule) {
        this.errors1.push('Matricule est obligatoire.');
      }
    },
    getbyid(id){
      axios.get(`Societe/${id}`)
      .then(reponse=>{
         this.societesid = reponse.data;
      })
    }
  }
};
</script>
<style>
#btn1 {
  float: right;
}
#btn2{
      margin: 23px;
}
.modal-content {
    border: 0px !important;
}

</style>
