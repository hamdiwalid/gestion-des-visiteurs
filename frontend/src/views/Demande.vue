<template>
  <div class="py-4 container-fluid">
    <div class="row">
      <div class="col-12">
        <demande />
      </div>
    </div>
  </div>
</template>

<script>
import demande from "./components/demande";


export default {
  name: "Demandes",
  components: {
    demande,
  },
};
</script>
