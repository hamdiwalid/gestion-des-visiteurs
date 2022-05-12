<template>
  <nav
    class="shadow-none navbar navbar-main navbar-expand-lg border-radius-xl"
    v-bind="$attrs"
    id="navbarBlur"
    data-scroll="true"
  >
    <div class="px-3 py-1 container-fluid">
      <breadcrumbs :currentPage="currentRouteName" :textWhite="textWhite" />
      <div
        class="mt-2 collapse navbar-collapse mt-sm-0 me-md-0 me-sm-4"
        :class="this.$store.state.isRTL ? 'px-0' : 'me-sm-4'"
        id="navbar"
      >
        <div
          class="pe-md-3 d-flex align-items-center"
          :class="this.$store.state.isRTL ? 'me-md-auto' : 'ms-md-auto'"
        >
        </div>
        <ul class="navbar-nav justify-content-end">
          <li class="nav-item d-flex align-items-center">
            <router-link @click="logout"
              :to="{ name: '/' }"
              class="px-0 nav-link font-weight-bold"
              :class="textWhite ? textWhite : 'text-body'"
            >
              <i
                class="fa fa-sign-out fa-lg"
                :class="this.$store.state.isRTL ? 'ms-sm-2' : 'me-sm-1'"
              ></i>
              
            </router-link>
          </li>
          <li class="nav-item d-xl-none ps-3 d-flex align-items-center">
            <a
              href="#"
              @click="toggleSidebar"
              class="p-0 nav-link text-body"
              id="iconNavbarSidenav"
            >
              <div class="sidenav-toggler-inner">
                <i class="sidenav-toggler-line"></i>
                <i class="sidenav-toggler-line"></i>
                <i class="sidenav-toggler-line"></i>
              </div>
            </a>
          </li>
          <li class="px-3 nav-item d-flex align-items-center">
           
          </li>
          <li
            class="nav-item dropdown d-flex align-items-center"
            :class="this.$store.state.isRTL ? 'ps-2' : 'pe-2'"
          >
            <a
              href="#"
              class="p-0 nav-link"
              :class="[
                textWhite ? textWhite : 'text-body',
                showMenu ? 'show' : '',
              ]"
              id="dropdownMenuButton"
              data-bs-toggle="dropdown"
              aria-expanded="false"
              @click="showMenu = !showMenu"
            >
              <i class="cursor-pointer fa fa-bell"></i>
              <span v-if="Notification.length != 0 && role=='responsable' || Notifications.length != 0 && role=='assistant'" class="notification">{{Notification.length}}</span>
              <span v-if="Notifications.length != 0 && role=='admin' || Notifications.length != 0 && role=='agent'" class="notification">{{Notifications.length}}</span>
            </a>
            <ul v-if="role=='responsable' || role=='assistant'"
              class="px-2 py-3 dropdown-menu dropdown-menu-end me-sm-n4"
              :class="showMenu ? 'show' : ''"
              aria-labelledby="dropdownMenuButton"
            >
              <li  class="mb-2" v-for="notif in Notification" :key="notif.id">
                <a @click="lire(notif.id)" class="dropdown-item border-radius-md" href="javascript:;">
                  <div class="py-1 d-flex">
                    <div class="my-auto">
                      <img
                        src="../../assets/img/team-2.jpg"
                        class="avatar avatar-sm me-3"
                        alt="user image"
                      />
                    </div>
                    <div class="d-flex flex-column justify-content-center">
                      <h6 class="mb-1 text-sm font-weight-normal">
                        <span class="font-weight-bold">{{notif.titre}}</span> de
                        <div v-for="user in users" :key="user.UserId">
                        <div v-if="user.UserId == notif.UserId">
                          {{ user.nom }} {{ user.prenom }}
                        </div>
                        </div>
                      </h6>
                      <!--p class="mb-0 text-xs text-secondary">
                        <i class="fa fa-clock me-1"></i>
                        13 minutes ago
                      </p-->
                    </div>
                  </div>
                </a>
              </li>
            </ul>
            <ul v-if="role=='admin' || role=='agent'"
              class="px-2 py-3 dropdown-menu dropdown-menu-end me-sm-n4"
              :class="showMenu ? 'show' : ''"
              aria-labelledby="dropdownMenuButton"
            >
              <li  class="mb-2" v-for="notifs in Notifications" :key="notifs.id">
                <a @click="lire(notifs.id)" class="dropdown-item border-radius-md" href="javascript:;">
                  <div class="py-1 d-flex">
                    <div class="my-auto">
                      <img
                        src="../../assets/img/team-2.jpg"
                        class="avatar avatar-sm me-3"
                        alt="user image"
                      />
                    </div>
                    <div class="d-flex flex-column justify-content-center">
                      <h6 class="mb-1 text-sm font-weight-normal">
                        <span class="font-weight-bold">{{notifs.titre}}</span> de
                        <div v-for="user in users" :key="user.UserId">
                        <div v-if="user.UserId == notifs.UserId">
                          {{ user.nom }} {{ user.prenom }}
                        </div>
                        </div>
                      </h6>
                      <!--p class="mb-0 text-xs text-secondary">
                        <i class="fa fa-clock me-1"></i>
                        13 minutes ago
                      </p-->
                    </div>
                  </div>
                </a>
              </li>
            </ul>
          </li>
        </ul>
      </div>
    </div>
  </nav>
</template>
<script>
import Breadcrumbs from "../Breadcrumbs.vue";
import { mapMutations, mapActions } from "vuex";
import axios from 'axios';
export default {
  name: "navbar",
  data() {
    return {
      showMenu: false,
      Notification:[],
      Notifications:[],
      users:[]
    };
  },
  props: ["minNav", "textWhite"],
  created() {
    this.minNav;
    this.user = JSON.parse(localStorage.getItem("currentUser"));
    if(this.user != null){
    this.userid = this.user.UserId;
    var id = this.user.SocieteId;
    axios.get(`Notification/societe?id=${id}&id1=${this.userid}`)
      .then(reponse=>{
         this.Notification = reponse.data;
         this.length = this.Notification.length
      });
      axios.get(`Notification?id=${this.userid}`)
      .then(reponse=>{
         this.Notifications = reponse.data;
      });
    }
    this.role = localStorage.getItem("role");
    
      axios.get(`User`)
      .then(reponse=>{
         this.users = reponse.data;
      });
  },
  methods: {
    ...mapMutations(["navbarMinimize", "toggleConfigurator"]),
    ...mapActions(["toggleSidebarColor"]),

    toggleSidebar() {
      this.toggleSidebarColor("bg-white");
      this.navbarMinimize();
    },
    logout() {
    localStorage.removeItem('currentUser');
    localStorage.removeItem('role');
  },
  lire(id){
    axios.put(`Notification?id=${id}`,{
        etat:"lu"
      })
      .then(reponse=>{
        axios.get(`Notification/societe?id=${id}&id1=${this.userid}`)
      .then(reponse=>{
         this.Notification = reponse.data;
         this.length = this.Notification.length
      });
      axios.get(`Notification?id=${this.userid}`)
      .then(reponse=>{
         this.Notifications = reponse.data;
      });
      console.log(reponse)
      location.reload()
      })
  }
  },
  components: {
    Breadcrumbs,
  },
  computed: {
    currentRouteName() {
      return this.$route.name;
    },
  },
  updated() {
    const navbar = document.getElementById("navbarBlur");
    window.addEventListener("scroll", () => {
      if (window.scrollY > 10 && this.$store.state.isNavFixed) {
        navbar.classList.add("blur");
        navbar.classList.add("position-sticky");
      } else {
        navbar.classList.remove("blur");
        navbar.classList.remove("position-sticky");
      }
    });
  },
};
</script>
<style>
.notification {
    position: absolute;
    top: 1px;
    border: 1px solid #FFF;
    right: 12px;
    font-size: 9px;
    background: #f44336;
    color: #FFFFFF;
    min-width: 12px;
    padding: 0px 5px;
    height: 18px;
    border-radius: 10px;
    text-align: center;
    line-height: 19px;
    vertical-align: middle;
    display: block;
}
</style>
