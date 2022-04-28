import axios from "axios";

axios.defaults.baseURL='http://localhost:57484/api';
axios.defaults.headers.post['Access-Control-Allow-Origin'] = '*';
axios.headers = {
    "Content-Type": "application/json"
  }