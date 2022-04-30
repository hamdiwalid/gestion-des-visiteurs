<template>
  <div class="card mb-4">
    <div class="card-header pb-0">
      <h6>Agents sécurités</h6>
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
            <tr v-for="agent in agents" :key="agent.UserId">
              <td class="align-middle text-center">
                {{agent.UserId}}
              </td>
              <td class="align-middle text-center">
                 {{agent.nom}}
              </td>
              <td class="align-middle text-center">
                {{agent.prenom}}
              </td>
              <td class="align-middle text-center">
                {{agent.CIN}}
              </td>
              <td class="align-middle text-center"></td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>

<script>
import img1 from "../../assets/img/team-2.jpg";
import img2 from "../../assets/img/team-3.jpg";
import img3 from "../../assets/img/team-4.jpg";
import img4 from "../../assets/img/team-3.jpg";
import img5 from "../../assets/img/team-2.jpg";
import img6 from "../../assets/img/team-4.jpg";
import axios from 'axios';
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
      agents:null
    };
  },
  components: {
  },
  async created(){
      axios.get('Agent')
      .then(reponse=>{
         this.agents = reponse.data;
        console.log(this.agents);
      })
  },
  methods:{

  }
};
</script>
