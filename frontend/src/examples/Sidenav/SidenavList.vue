<template>
  <div
    class="w-auto h-auto collapse navbar-collapse max-height-vh-100 h-100"
    id="sidenav-collapse-main"
  >
    <ul class="navbar-nav">
      <li class="nav-item" v-if="role == 'admin'">
        <sidenav-collapse navText="Les demandes" :to="{ name: 'Demandes' }">
          <template #icon>
            <document />
          </template>
        </sidenav-collapse>
      </li>
      <li class="nav-item" v-if="role == 'responsable' || role == 'assistant'">
        <sidenav-collapse navText="Les demandes" :to="{ name: 'Demandes sociéte' }">
          <template #icon>
            <document />
          </template>
        </sidenav-collapse>
      </li>
      <li class="nav-item" v-if="role == 'agent'">
        <sidenav-collapse navText="Les demandes" :to="{ name: 'Demandes agent' }">
          <template #icon>
            <document />
          </template>
        </sidenav-collapse>
      </li>
      <li class="nav-item" v-if="role == 'admin'">
        <sidenav-collapse navText="Agent sécurité" :to="{ name: 'Agents' }">
          <template #icon>
            <document />
          </template>
        </sidenav-collapse>
      </li>
      <li class="nav-item" v-if="role == 'admin'">
        <sidenav-collapse navText="Responsable société" :to="{ name: 'Responsables' }">
          <template #icon>
            <document />
          </template>
        </sidenav-collapse>
      </li>
      <li class="nav-item" v-if="role == 'responsable'  ">
        <sidenav-collapse navText="Liste des assistants" :to="{ name: 'Assistants' }">
          <template #icon>
            <document />
          </template>
        </sidenav-collapse>
      </li>
      <li class="nav-item">
        <sidenav-collapse navText="Profile" :to="{ name: 'Profile' }">
          <template #icon>
            <customer-support />
          </template>
        </sidenav-collapse>
      </li>
      <li class="nav-item" v-if="role == 'admin'">
        <sidenav-collapse navText="Sociétes" :to="{ name: 'Sociéte' }">
          <template #icon>
            <document />
          </template>
        </sidenav-collapse>
      </li>
      <li class="nav-item" v-if="role == 'admin'">
        <sidenav-collapse navText="Historique" :to="{ name: 'Historique' }">
          <template #icon>
            <document />
          </template>
        </sidenav-collapse>
      </li>
      <li class="nav-item" v-if="role == 'responsable' || role == 'assistant'">
        <sidenav-collapse navText="Historique" :to="{ name: 'Historique sociéte' }">
          <template #icon>
            <document />
          </template>
        </sidenav-collapse>
      </li>
      <li class="nav-item" v-if="role == 'agent'">
        <sidenav-collapse navText="Historique" :to="{ name: 'Historique agent' }">
          <template #icon>
            <document />
          </template>
        </sidenav-collapse>
      </li>
    </ul>
  </div>

</template>
<script>
import SidenavCollapse from "./SidenavCollapse.vue";
import CustomerSupport from "../../components/Icon/CustomerSupport.vue";
import Document from "../../components/Icon/Document.vue";
export default {
  name: "SidenavList",
  props: {
    cardBg: String,
  },
  data() {
    return {
      title: "Soft UI Dashboard PRO",
      controls: "dashboardsExamples",
      isActive: "active",
      user: null,
      role: null
    };
  },
  async created(){
      this.user = localStorage.getItem("currentUser");
      this.role = localStorage.getItem("role");
  },
  components: {
    SidenavCollapse,
    CustomerSupport,
    Document,
  },
  computed: {
    currentRouteName() {
      return this.$route.name;
    },
  },
  methods: {
    getRoute() {
      const routeArr = this.$route.path.split("/");
      return routeArr[1];
    }
  },
};
</script>
