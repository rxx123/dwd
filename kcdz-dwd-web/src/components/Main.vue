<template>
    <el-row class="container">
        <el-col :span="24" class="header">
        <el-col :span="10" class="logo" :class="collapsed?'logo-collapse-width':'logo-width'">
            {{collapsed?'':sysName}}        
        </el-col>      
        <el-col :span="10">
            <!-- <div class="tools" @click.prevent="collapse">
            <i class="fa fa-align-justify"></i>
            </div> -->
        </el-col>
        <el-col :span="4" class="userinfo">
            <el-dropdown trigger="hover">
            <!-- <span class="el-dropdown-link userinfo-inner"><img :src="this.sysUserAvatar"/> {{sysUserName}}</span> -->
            <span class="el-dropdown-link userinfo-inner">{{sysUserName}}</span>
            <el-dropdown-menu slot="dropdown">
                <el-dropdown-item>我的消息</el-dropdown-item>
                <el-dropdown-item>设置</el-dropdown-item>
                <el-dropdown-item divided @click.native="logout">退出登录</el-dropdown-item>
            </el-dropdown-menu>
            </el-dropdown>
        </el-col>
        </el-col>
        <el-col :span="24" class="main">
        <div class="container">        
            <iframe src="http://127.0.0.1:2112/xiandianwuduan.html" class="ifr"></iframe>  
        </div>
        </el-col>
    </el-row>
</template>


<script>
import { requestStation } from '../api/api';
export default {
  data () {
    return {          
      sysName: '西安电务段',
      collapsed: false,
      sysUserName: '',
      // sysUserAvatar: '',
      form: {
        name: '',
        region: '',
        date1: '',
        date2: '',
        delivery: false,
        type: [],
        resource: '',
        desc: ''
      }
    }
  },
  computed: {
    // 关于v-for v-if，data里未定义的变量遍历使用计算属性。否则使用v-for v-if配合使用
    routes: function () {
      return this.$router.options.routes.filter(function (item) {
        return !item.hidden
      })
    },
    // 利用闭包实现计算属性传参。
    routeChildren: function (route) {
      return function (route) {
        return route.children.filter(function (child) {
          return !child.hidden
        })
      }
    }
  },
  methods: {
    onSubmit () {
      console.log('submit!')
    },
    handleopen () {
      // console.log('handleopen');
    },
    handleclose () {
      // console.log('handleclose');
    },
    handleselect: function (a, b) {
    },
    // 退出登录
    logout: function () {
      var _this = this
      this.$confirm('确认退出吗?', '提示', {
        // type: 'warning'
      }).then(() => {
        sessionStorage.removeItem('user')
        _this.$router.push('/Login')
      }).catch(() => {

      })
    },
    // 折叠导航栏
    collapse: function () {
      this.collapsed = !this.collapsed
    },
    showMenu (i, status) {
      this.$refs.menuCollapsed.getElementsByClassName('submenu-hook-' + i)[0].style.display = status ? 'block' : 'none'
    },
    //站场选择
    selectChage:function(){
      // alert(this.selectValue);
      sessionStorage.setItem('station', this.selectValue);
    }
  },
  mounted () {
    var user = sessionStorage.getItem('user');
    if (user) {
      user = JSON.parse(user);
      this.sysUserName = user.UserName || ''
      // this.sysUserAvatar = user.avatar || ''
    }
    requestStation().then(data => {
      if (data.Result) {
        this.options=data.Data;       
      } else {
        this.$message({
          message: data.Msg,
          type: 'error'
        });
      }
    });
  }
}

</script>



<style scoped lang="scss">
  @import '../styles/vars'; 
  .container {
    position: absolute;
    top: 0px;
    bottom: 0px;
    width: 100%;
    padding-right: 0; 
    padding-left: 0;
    margin-right: auto; 
    margin-left: auto;     
    .header {
      height: 60px;
      line-height: 60px;
      background: $color-primary;
      color: #fff;

      .userinfo {
        text-align: right;
        padding-right: 35px;
        float: right;

        .userinfo-inner {
          cursor: pointer;
          color: #fff;

          img {
            width: 40px;
            height: 40px;
            border-radius: 20px;
            margin: 10px 0px 10px 10px;
            float: right;
          }
        }
      }

      .logo {
        height: 60px;
        font-size: 22px;
        padding-left: 20px;
        padding-right: 20px;
        border-color: rgba(238, 241, 146, 0.3);
        border-right-width: 1px;
        border-right-style: solid;

        img {
          width: 40px;
          float: left;
          margin: 10px 10px 10px 18px;
        }

        .txt {
          color: #fff;
        }
      }

      .logo-width {
        width: 230px;
        text-align: center;
      }

      .logo-collapse-width {
        width: 60px
      }

      .tools {
        padding: 0px 23px;
        width: 14px;
        height: 60px;
        line-height: 60px;
        cursor: pointer;
      }
    }

    .main {
      display: flex;
      position: absolute;
      top: 60px;
      bottom: 0px;
      overflow: hidden;
      .ifr {
        width: 100%;
        height: 100%;
        }
    }
}
</style>