<template>
  <div class="card mb-4">
    <div class="card-header pb-0">
      <h6>Assistants</h6>
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
              <th class="text-secondary opacity-7"></th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="assistant in assistants" :key="assistant.UserId">
              <td class="align-middle text-center">
                {{assistant.UserId}}
              </td>
              <td class="align-middle text-center">
                 {{assistant.nom}}
              </td>
              <td class="align-middle text-center">
                {{assistant.prenom}}
              </td>
              <td class="align-middle text-center">
                {{assistant.CIN}}
              </td>
              <td class="align-middle text-center">
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
  <ModalC @close="toggleModal" :modalActive="modalActive">
      <div class="modal-content">
        <h4>Ajouter agent</h4>
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
                    <label>Mot de passe</label>
                    <input
                      id="password"
                      type="password"
                      placeholder="Password"
                      class="form-control"
                      name="motpasse"
                      v-model="motpasse"
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
                    <label>Mot de passe</label>
                    <input
                      id="password"
                      type="password"
                      placeholder="Password"
                      class="form-control"
                      name="motpasse"
                      v-model="motpasse"
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
                    <label>Mot de passe</label>
                    <input
                      id="password"
                      type="password"
                      placeholder="Password"
                      class="form-control"
                      name="motpasse"
                      v-model="motpasse"
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
                      <button
                        class="btn btn-success mb-4"
                        variant="gradient"
                        color="success"
                        id="btn2"
                        >Connexion
                      </button>
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
  name: "assistant",
  data() {
    return {
      img1,
      img2,
      img3,
      img4,
      img5,
      img6,
      assistants:null
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
      axios.get('Assistant')
      .then(reponse=>{
         this.assistants = reponse.data;
        console.log(this.assistants);
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
    top: 141px !important;
}
</style>
