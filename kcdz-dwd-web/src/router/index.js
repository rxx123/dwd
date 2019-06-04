import Vue from 'vue'
import Router from 'vue-router'
import Login from '@/components/Login'
import Form from '@/components/Form'
import Home from '@/components/Home'
import Main from '@/components/Main'
import DrawingShow from '@/components/drawing/DrawingShow'
import DrawingSearch from '@/components/drawing/DrawingSearch'
import EquipmentLedger from '@/components/equipment/EquipmentLedger'
import EquipmentOverhaul from '@/components/overhaul/EquipmentOverhaul'
import EquipmentMaintain from '@/components/overhaul/EquipmentMaintain'
import EquipmentCentralized from '@/components/overhaul/EquipmentCentralized'
import FaultManagement from '@/components/breakdown/FaultManagement'
import BasicInformationManagement from '@/components/system/BasicInformationManagement'
import UserPrivilegeManagement from '@/components/system/UserPrivilegeManagement'
import UserInformationManagement from '@/components/system/UserInformationManagement'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Login',
      hidden:true,
      component: Login
    },
    {
      path: '/Form',
      name: 'Form',
      hidden:true,
      component: Form,
      props: (route) => ({ query: route.query.q })
    },
    {
      path: '/Main',
      name: 'Main',
      hidden:true,
      component: Main
    },
    {
      path: '/Home/:id',
      name: 'Home',
      hidden:true,
      component: Home
    },
    {
      path: '/',
      component: Home,
      name: '图纸管理',
      iconCls: 'el-icon-s-platform', // 图标样式class
      children: [
        { 
          path: '/DrawingShow', 
          component: DrawingShow, 
          name: '图纸显示管理'
        },
        { path: '/DrawingSearch', component: DrawingSearch, name: '图纸检索管理' }
      ]
    },
    {
      path: '/',
      component: Home,
      name: '台账管理',
      iconCls: 'el-icon-s-shop',
      children: [
        { path: '/EquipmentLedger', component: EquipmentLedger, name: '设备台账管理' }
        // { path: '/EquipmentOverhaul', component: EquipmentOverhaul, name: '设备检修管理' },
        // { path: '/EquipmentMaintain', component: EquipmentMaintain, name: '设备养护管理' }
      ]
    },
    {
      path: '/',
      component: Home,
      name: '检修管理',
      iconCls: 'el-icon-s-shop',
      children: [
        { path: '/EquipmentOverhaul', component: EquipmentOverhaul, name: '设备大修管理' },
        { path: '/EquipmentCentralized', component: EquipmentCentralized, name: '集中维修管理' },
        { path: '/EquipmentMaintain', component: EquipmentMaintain, name: '日常养护管理' }
      ]
    },
    // {
    //   path: '/',
    //   component: Home,
    //   name: '检修作业',
    //   iconCls: 'el-icon-s-cooperation',
    //   children: [
    //     { path: '/page7', component: Home, name: '作业指导与部署' },
    //     { path: '/page8', component: Home, name: '检修作业计划' }
    //   ]
    // },
    {
      path: '/',
      component: Home,
      name: '故障处置',
      iconCls: 'el-icon-s-open',
      children: [
        { path: '/FaultManagement', component: FaultManagement, name: '故障处置管理' }
      ]
    },
    {
      path: '/',
      component: Home,
      name: '系统管理',
      iconCls: 'el-icon-s-tools',
      children: [
        { path: '/UserInformationManagement', component: UserInformationManagement, name: '用户信息管理' },
        { path: '/UserPrivilegeManagement', component: UserPrivilegeManagement, name: '用户权限管理' },
        { path: '/BasicInformationManagement', component: BasicInformationManagement, name: '基础信息管理' }
      ]
    }
  ]
})
