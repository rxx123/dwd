<template>
    <div>   
        <el-tabs v-model="activeName" type="border-card" @tab-click="handleClick">
            <el-tab-pane  v-for="item in drawings" :key="item.Id" :label="item.DrawingName" :name="item.DrawingName">
                <iframe :src="item.DrawingUrl" class="ifr"></iframe>
            </el-tab-pane>
        </el-tabs>        
    </div>
</template>
<script>
  import { requestDrawing } from '../../api/api';
  export default {
    data() {
      return {
        activeName: '站场平面图',
        drawings:[]
      };
    },
    methods: {
      handleClick(tab, event) {
        this.tabType = tab.index;
      }
    },
    mounted () {
      requestDrawing(sessionStorage.getItem('station')).then(data => {
        if (data.Result) {
          this.drawings=data.Data;
        } else {
          this.$message({
            message: data.Msg,
            type: 'error'
          });
        }
      });
    }
  };
</script>

<style scoped lang="scss">
    .ifr {
        width:100%;
        height: 700px;
    }
</style>