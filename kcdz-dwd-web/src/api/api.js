import axios from 'axios';

let base = 'http://localhost:54942/api';
axios.defaults.headers.post['Content-Type'] = 'application/json';

// export const requestLogin = param => { return axios.get(`${base}/Login`, { params: param }); };
export const requestLogin = param => { return axios.post(`${base}/Login`, param).then(res => res.data); };
export const requestEquipmentLedgerGet = param => { return axios.post(`${base}/EquipmentLedger/get`, param).then(res => res.data); };
export const requestEquipmentLedgerPost = param => { return axios.post(`${base}/EquipmentLedger`, param).then(res => res.data); };
export const requestEquipmentLedgerPut = param => { return axios.put(`${base}/EquipmentLedger`, param).then(res => res.data); };
export const requestEquipmentLedgerDelete = param => { return axios.delete(`${base}/EquipmentLedger/`+param).then(res => res.data); };
export const requestStation = param => { return axios.get(`${base}/Station`).then(res => res.data); };
export const requestDrawing = param => { return axios.get(`${base}/Drawing/`+ param).then(res => res.data); };