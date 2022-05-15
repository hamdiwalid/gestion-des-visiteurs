<template>
  <div class="card mb-4">
    <div class="card-header pb-0">
      <h6>Responsables</h6>
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
                ID
              </th>
              <th
                class="text-center text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"
              >
                Nom
              </th>
              <th
                class="text-center text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"
              >
                Prénom
              </th>
              <th
                class="text-center text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"
              >
                CIN
              </th>
              <th
                class="text-center text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"
              >Action</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="responsable in filteredItems" :key="responsable.UserId">
              <td class="align-middle text-center">
                 {{responsable.UserId}}
              </td>
              <td class="align-middle text-center">
                 {{responsable.nom}}
              </td>
              <td class="align-middle text-center">
                {{responsable.prenom}}
              </td>
              <td class="align-middle text-center">
                {{responsable.CIN}}
              </td>
              <td class="align-middle text-center">
                <div class="ms-auto text-end">
            <a @click="sup(responsable.UserId)"
              class="btn btn-link text-danger text-gradient px-3 mb-0"
            >
              <i class="far fa-trash-alt me-2" aria-hidden="true"></i>Supprimer
            </a>
            <router-link :to="`/modifierresponsable/${responsable.UserId}`">
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
        <h4>Ajouter responsable</h4>
        <form role="form" class="text-start">
                    <label>Identifiant</label>
                    <input
                      id="identifiant"
                      type="string"
                      placeholder="Identifiant"
                      class="form-control"
                      name="identifiant"
                      v-model="identifiant"
                    />
                    <label>Nom</label>
                    <input
                      id="nom"
                      type="string"
                      placeholder="Nom"
                      class="form-control"
                      name="nom"
                      v-model="nom"
                    />
                    <label>Prénom</label>
                    <input
                      id="prenom"
                      type="string"
                      placeholder="Prénom"
                      class="form-control"
                      name="prenom"
                      v-model="prenom"
                    />
                    <label>Mot de passe</label>
                    <input
                      id="password"
                      type="password"
                      placeholder="Password"
                      class="form-control"
                      name="motpasse"
                      v-model="motpasse"
                    />
                    <label>CIN</label>
                    <input
                      id="cin"
                      type="number"
                      placeholder="CIN"
                      class="form-control"
                      name="cin"
                      v-model="cin"
                    />
                    <label>Sociéte</label>
                    <select class="form-control" id="societech" name="societech" v-model="societech">
                      <option v-for="societe in societes" :key="societe.id" v-bind:value="societe.id">{{ societe.nom }} </option>
                    </select>
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
import img1 from "../../assets/img/team-2.jpg";
import img2 from "../../assets/img/team-3.jpg";
import img3 from "../../assets/img/team-4.jpg";
import img4 from "../../assets/img/team-3.jpg";
import img5 from "../../assets/img/team-2.jpg";
import img6 from "../../assets/img/team-4.jpg";
import axios from 'axios';
import ModalC from "./ModalC.vue";
import { ref } from "vue";
import VsudButton from "@/components/VsudButton.vue";
export default {
  name: "responsable",
  data() {
    return {
      img1,
      img2,
      img3,
      img4,
      img5,
      img6,
      responsables:null,
      societes:null,
      identifiant:'',
      nom:'',
      prenom:'',
      motpasse:'',
      cin:null,
      societech:null,
      errors: [],
      search:"",
      table:[],
      errors1: [],
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
      axios.get('Responsable')
      .then(reponse=>{
         this.responsables = reponse.data;
         for (let i = 0; i < this.responsables.length; i++) {
           this.table.push(this.responsables[i]);
         }
      });
      axios.get('Societe')
      .then(reponse =>{
        this.societes = reponse.data;
      })
  },
  computed: {
    filteredItems() {
      return  this.table.filter((item) => {
        return item.nom.toLowerCase().includes(this.search.toLowerCase()) || item.prenom.toLowerCase().includes(this.search.toLowerCase());
      });
    },
  },
  methods:{
ajouter: function(e){
      if (this.identifiant && this.nom && this.prenom && this.motpasse && this.cin && this.societech) {
      axios.post('User',{
        identifiant:this.identifiant,
        nom:this.nom,
        prenom:this.prenom,
        motpasse:this.motpasse,
        role:"responsable",
        CIN:this.cin,
        societeId:this.societech
      })
      .then(reponse=>{
        axios.get('Responsable')
      .then(reponse=>{
         this.responsables = reponse.data;
      });
        console.log(reponse)
        location.reload()
      })
      }
       this.errors = [];

      if (!this.identifiant) {
        this.errors.push('Identifiant est obligatoire.');
      }
      if (!this.nom) {
        this.errors.push('Nom est obligatoire.');
      }
      if (!this.prenom) {
        this.errors.push('Prenom est obligatoire.');
      }
      if (!this.motpasse) {
        this.errors.push('Mot de passe est obligatoire.');
      }
      if (!this.cin) {
        this.errors.push('CIN est obligatoire.');
      }
      if (!this.societech) {
        this.errors.push('Sociéte est obligatoire.');
      }

      e.preventDefault();
    },
    sup(id){
      axios.delete(`User?id=${id}`)
      .then(reponse=>{
        axios.get('Responsable')
      .then(reponse=>{
         this.responsables = reponse.data;
      });
        console.log(reponse)
      })
    },
    modifier(id,identifiant,nom,prenom,CIN){
      if (identifiant && nom && prenom && CIN) {
        axios.put(`User?id=${id}`,{
        identifiant:identifiant,
        nom:nom,
        prenom:prenom,
        CIN:CIN,
        societeId:0
      })
      .then(reponse=>{
         console.log(reponse)
         location.reload()
      })
      }
       this.errors1 = [];

      if (!identifiant) {
        this.errors1.push('Identifiant est obligatoire.');
      }
      if (!nom) {
        this.errors1.push('Nom est obligatoire.');
      }
      if (!prenom) {
        this.errors1.push('Prenom est obligatoire.');
      }
      if (!CIN) {
        this.errors1.push('CIN est obligatoire.');
      }
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
