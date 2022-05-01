<template>
  <div class="card mb-4">
    <div class="card-header pb-0">
      <h6>Demandes</h6>
            <button @click="toggleModal" type="button" id="btn1" class="btn btn-success mb-4">+</button>
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
                Motivé
              </th>
              <th
                class="text-center text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"
              >
                Description
              </th>
              <th
                class="text-center text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"
              >
                Utilisateur
              </th>
              <th
                class="text-center text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"
              >
                Sociéte
              </th>
              <th class="text-secondary opacity-7"></th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="demande in demandes" :key="demande.id">
              <td class="align-middle text-center">
                {{demande.id}}
              </td>
              <td class="align-middle text-center">
                 {{demande.motive}}
              </td>
              <td class="align-middle text-center">
                {{demande.description}}
              </td>
              <td class="align-middle text-center">
                {{demande.UserId}}
              </td>
              <td class="align-middle text-center">
               {{demande.Societeid}}
              </td>
              <td></td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>

<ModalC @close="toggleModal" :modalActive="modalActive">
      <div class="modal-content">
        <h4>Ajouter une demande</h4>
        <form role="form" @submit.prevent="login" class="text-start">
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
                      placeholder="Password"
                      class="form-control"
                      name="motpasse"
                      v-model="motpasse"
                    />
                    <div class="text-center">
                      <vsud-button
                        class="btn btn-success mb-4"
                        variant="gradient"
                        color="success"
                        id="btn2"
                        >Connexion
                      </vsud-button>
                    </div>
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
export default {
  name: "demande",
  data() {
    return {
      img1,
      img2,
      img3,
      img4,
      img5,
      img6,
      demandes:null
    };
  },
  components: {
    ModalC
  },
  setup() {
    const modalActive = ref(false);
    const toggleModal = () => {
      modalActive.value = !modalActive.value;
    };
    return { modalActive, toggleModal };
  },
  async created(){
      axios.get('Demande')
      .then(reponse=>{
         this.demandes = reponse.data;
        console.log(this.demandes);
      })
  },
  methods:{

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
.modal-inner {
    top: 0 !important;
}
</style>