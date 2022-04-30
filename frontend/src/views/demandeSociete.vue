<template>
  <div class="py-4 container-fluid">
    <div class="row">
      <div class="col-12">
        <demandesociete />
      </div>
    </div>
  </div>
</template>

<script>
import demandesociete from "./components/demandesociete";


export default {
  name: "DemandesSociete",
  components: {
    demandesociete,
  },
};
</script>
