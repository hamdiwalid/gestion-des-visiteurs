<template>
  <div class="container top-0 position-sticky z-index-sticky">
    <div class="row">
      <div class="col-12">
        <navbar
          is-blur="blur blur-rounded my-3 py-2 start-0 end-0 mx-4 shadow"
          btn-background="bg-gradient-success"
          :dark-mode="true"
        />
      </div>
    </div>
  </div>
  <main class="mt-0 main-content main-content-bg">
    <section>
      <div class="page-header min-vh-75">
        <div class="container">
          <div class="row">
            <div class="mx-auto col-xl-4 col-lg-5 col-md-6 d-flex flex-column">
              <div class="mt-8 card card-plain">
                <div class="pb-0 card-header text-start">
                  <h3 class="font-weight-bolder text-success text-gradient">
                    Bienvenue
                  </h3>
                  <p class="mb-0">Entrez votre identifiant et votre mot de passe pour ouvrir une session</p>
                </div>
                <div class="card-body">
                  <form role="form" @submit.prevent="checkForm" class="text-start">
                    <label>Identifiant</label>
                    <input
                      id="identifiant"
                      type="string"
                      placeholder="Identifiant"
                      class="form-control"
                      name="identifiant"
                      v-model="identifiant"
                    />
                    <label>Mot de passe</label>
                    <input
                      id="password"
                      type="password"
                      placeholder="Mot de passe"
                      class="form-control"
                      name="motpasse"
                      v-model="motpasse"
                    />
                    <div class="text-center">
                      <vsud-button
                        class="my-4 mb-2"
                        variant="gradient"
                        color="success"
                        full-width
                        >Connexion
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
              </div>
            </div>
            
            <div class="col-md-6">
              <div
                class="top-0 oblique position-absolute h-100 d-md-block d-none me-n8"
              >
                <div
                  class="bg-cover oblique-image position-absolute fixed-top ms-auto h-100 z-index-0 ms-n6"
                  :style="{
                    backgroundImage:
                      'url(' +
                      require('@/assets/img/curved-images/curved9.jpg') +
                      ')',
                  }"
                ></div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
  </main>
</template>

<script>
import Navbar from "@/examples/PageLayout/Navbar.vue";

import VsudButton from "@/components/VsudButton.vue";
const body = document.getElementsByTagName("body")[0];
import { mapMutations } from "vuex";
import axios from 'axios';
export default {
  name: "SignIn",
  data(){
    return{
      identifiant:'',
      motpasse: '',
      errors: [],
    }
      
  },
  components: {
    Navbar,
    VsudButton,
  },
  created() {
    this.toggleEveryDisplay();
    this.toggleHideConfig();
    body.classList.remove("bg-gray-100");
  },
  beforeUnmount() {
    this.toggleEveryDisplay();
    this.toggleHideConfig();
    body.classList.add("bg-gray-100");
  },
  methods: {
    ...mapMutations(["toggleEveryDisplay", "toggleHideConfig"]),

    checkForm: function (e) {
      if (this.identifiant && this.motpasse) {
        axios.post('login',{
        identifiant:this.identifiant,
        motpasse: this.motpasse
      }
      ).then(reponse =>{
        console.log(reponse)
        localStorage.setItem("currentUser",JSON.stringify(reponse.data[0]))
        localStorage.setItem("role", reponse.data[0].role)
         if(reponse.data[0].role == "admin"){
           this.$router.push({ path: '/demandes' })
         } else if(reponse.data[0].role == "responsable"){
           this.$router.push({ path: '/demandeSociete' })
         } else if(reponse.data[0].role == "assistant"){
           this.$router.push({ path: '/demandeSociete' })
         } else if(reponse.data[0].role == "agent"){
           this.$router.push({ path: '/demandeAgent' })
         }
      })
      }

      this.errors = [];

      if (!this.identifiant) {
        this.errors.push('Identifiant est obligatoire.');
      }
      if (!this.motpasse) {
        this.errors.push('Mot de passe est obligatoire.');
      }

      e.preventDefault();
    }
  },
};
</script>
<style>
#p{
  color: red;
}
</style>
