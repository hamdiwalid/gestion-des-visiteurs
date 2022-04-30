<template>
  <div class="py-4 container-fluid">
    <div class="row">
      <div class="col-12">
        <assistant />
      </div>
    </div>
  </div>
</template>

<script>
import assistant from "./components/assistant";


export default {
  name: "Assistants",
  components: {
    assistant,
  },
};
</script>
