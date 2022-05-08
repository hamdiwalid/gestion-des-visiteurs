<template>
  <div class="card h-100">
    <div class="p-3 pb-0 card-header">
      <div class="row">
        <div class="col-md-8 d-flex align-items-center">
          <h6 class="mb-0">{{ title }}</h6>
        </div>
        <div class="col-md-4 text-end">
          <a @click="toggleModal" type="button">
            <i
              class="text-sm fas fa-user-edit text-secondary"
              data-bs-toggle="tooltip"
              data-bs-placement="top"
              :title="action.tooltip"
            ></i>
          </a>
        </div>
      </div>
    </div>
    <div class="p-3 card-body">
      <p class="text-sm">
        {{ description }}
      </p>
      <hr class="my-4 horizontal gray-light" />
      <ul class="list-group">
        <li class="pt-0 text-sm border-0 list-group-item ps-0">
          <strong class="text-dark">Identifiant:</strong> &nbsp;
          {{ users.identifiant }}
        </li>
        <li class="pt-0 text-sm border-0 list-group-item ps-0">
          <strong class="text-dark">Nom:</strong> &nbsp;
          {{ users.nom }}
        </li>
        <li class="text-sm border-0 list-group-item ps-0">
          <strong class="text-dark">Prénom:</strong> &nbsp; {{ users.prenom }}
        </li>
        <li class="text-sm border-0 list-group-item ps-0">
          <strong class="text-dark">CIN:</strong> &nbsp; {{ users.CIN }}
        </li>
        <li class="text-sm border-0 list-group-item ps-0">
          <strong class="text-dark">Mot de passe:</strong> &nbsp; ********* 
          <a @click="toggleModal1">
          <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pencil-square" viewBox="0 0 16 16">
          <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z"/>
          <path fill-rule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z"/>
        </svg>
        </a>
        </li>
      </ul>
    </div>
  </div>
  <ModalC @close="toggleModal" :modalActive="modalActive">
      <div class="modal-content">
        <h4>Modifier profil</h4>
        <form role="form" class="text-start">
                    <label>Identifiant</label>
                    <input
                      id="identifiant"
                      type="string"
                      placeholder="Identifiant"
                      class="form-control"
                      name="identifiant"
                      v-model="users.identifiant"
                    />
                    <label>Nom</label>
                    <input
                      id="nom"
                      type="string"
                      placeholder="Nom"
                      class="form-control"
                      name="nom"
                      v-model="users.nom"
                    />
                    <label>Prénom</label>
                    <input
                      id="prenom"
                      type="string"
                      placeholder="Prénom"
                      class="form-control"
                      name="prenom"
                      v-model="users.prenom"
                    />
                    <label>CIN</label>
                    <input
                      id="cin"
                      type="number"
                      placeholder="CIN"
                      class="form-control"
                      name="cin"
                      v-model="users.cin"
                    />

                    <div class="text-center">
                      <vsud-button @click="modifier(users.identifiant,users.nom,users.prenom,users.cin)"
                        class="btn btn-success mb-4"
                        variant="gradient"
                        color="success"
                        id="btn2"
                        >Modifier
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
    <ModalC @close="toggleModal1" :modalActive="modalActive1">
      <div class="modal-content">
        <h4>Modifier mot de passe</h4>
        <form role="form" class="text-start">
                    <label>Ancien mot de passe</label>
                    <input
                      id="motpasse"
                      type="password"
                      placeholder="Ancien mot de passe"
                      class="form-control"
                      name="motpasse"
                      v-model="motpasse"
                    />
                    <label>Nouveau mot de passe</label>
                    <input
                      id="nmotpasse"
                      type="password"
                      placeholder="Nouveau mot de passe"
                      class="form-control"
                      name="nmotpasse"
                      v-model="nmotpasse"
                    />
                    <label>Confirmer mot de passe</label>
                    <input
                      id="cmotpasse"
                      type="password"
                      placeholder="Confirmer mot de passe"
                      class="form-control"
                      name="prenom"
                      v-model="cmotpasse"
                    />

                    <div class="text-center">
                      <vsud-button @click="modifierm(motpasse,nmotpasse,cmotpasse)"
                        class="btn btn-success mb-4"
                        variant="gradient"
                        color="success"
                        id="btn2"
                        >Modifier
                      </vsud-button>
                    </div>
                    <p id="p" v-if="errors1.length">
                        <b>Veuillez corriger les erreurs suivantes:</b>
                        <ul>
                        <li v-for="error in errors1 " :key="error">{{ error }}</li>
                        </ul>
                    </p>
                  </form>
      </div>
    </ModalC>
</template>

<script>
import ModalC from "./ModalC.vue";
import { ref } from "vue";
import axios from 'axios';
export default {
  name: "ProfileInfoCard",
  data() {
    return {
      showMenu: false,
      users:[],
      errors: [],
      errors1: [],
    };
  },
  components: {
    ModalC
  },
  created(){
   this.user = localStorage.getItem("currentUser");
   var id = this.user[10];
   axios.get(`User/${id}`)
      .then(reponse=>{
         this.users = reponse.data[0];
         console.log(this.users)
      });
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
  methods:{
    modifier(identifiant,nom,prenom,cin){
      var id = this.user[10];
      if( identifiant && nom && prenom && cin){
       axios.put(`User?id=${id}`,{
        identifiant:identifiant,
        nom:nom,
        prenom:prenom,
        cin:cin
      })
      .then(reponse=>{
          console.log(reponse)
          location.reload()
        })
      }
      this.errors = [];
      if (!identifiant) {
        this.errors.push('Identifiant est obligatoire.');
      }
      if (!nom) {
        this.errors.push('Nom est obligatoire.');
      }
      if (!prenom) {
        this.errors.push('Prenom est obligatoire.');
      }
      if (!cin) {
        this.errors.push('CIN est obligatoire.');
      }
    },
    modifierm(motpasse,nmotpasse,cmotpasse){
      var id = this.user[10];
      if( motpasse && nmotpasse && cmotpasse){
       axios.put(`User/motpasse?id=${id}`,{
        motpasse:nmotpasse
      })
      .then(reponse=>{
          console.log(reponse)
          location.reload()
        })
      }
      this.errors1 = [];
      if (motpasse != this.users.motpasse) {
        this.errors1.push('Mot de passe incorrect.');
      }
      if (!nmotpasse) {
        this.errors1.push('Nouveau mot de passe est obligatoire.');
      }
      if (nmotpasse != cmotpasse) {
        this.errors1.push('Le mot de passe ne correspond pas.');
      }
    }
  },
  props: {
    title: {
      type: String,
      default: "",
    },
    description: {
      type: String,
      default: "",
    },
    info: {
      type: Object,
      fullName: String,
      mobile: String,
      email: String,
      location: String,
      default: () => {},
    },
    social: {
      type: Array,
      link: String,
      icon: String,
      default: () => [],
    },
    action: {
      type: Object,
      route: String,
      tooltip: String,
      default: () => ({
        route: "javascript:;",
      }),
    },
  },
};
</script>
