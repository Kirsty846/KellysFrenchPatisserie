(function(t){function e(e){for(var r,c,i=e[0],u=e[1],l=e[2],p=0,d=[];p<i.length;p++)c=i[p],Object.prototype.hasOwnProperty.call(o,c)&&o[c]&&d.push(o[c][0]),o[c]=0;for(r in u)Object.prototype.hasOwnProperty.call(u,r)&&(t[r]=u[r]);s&&s(e);while(d.length)d.shift()();return a.push.apply(a,l||[]),n()}function n(){for(var t,e=0;e<a.length;e++){for(var n=a[e],r=!0,i=1;i<n.length;i++){var u=n[i];0!==o[u]&&(r=!1)}r&&(a.splice(e--,1),t=c(c.s=n[0]))}return t}var r={},o={app:0},a=[];function c(e){if(r[e])return r[e].exports;var n=r[e]={i:e,l:!1,exports:{}};return t[e].call(n.exports,n,n.exports,c),n.l=!0,n.exports}c.m=t,c.c=r,c.d=function(t,e,n){c.o(t,e)||Object.defineProperty(t,e,{enumerable:!0,get:n})},c.r=function(t){"undefined"!==typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(t,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(t,"__esModule",{value:!0})},c.t=function(t,e){if(1&e&&(t=c(t)),8&e)return t;if(4&e&&"object"===typeof t&&t&&t.__esModule)return t;var n=Object.create(null);if(c.r(n),Object.defineProperty(n,"default",{enumerable:!0,value:t}),2&e&&"string"!=typeof t)for(var r in t)c.d(n,r,function(e){return t[e]}.bind(null,r));return n},c.n=function(t){var e=t&&t.__esModule?function(){return t["default"]}:function(){return t};return c.d(e,"a",e),e},c.o=function(t,e){return Object.prototype.hasOwnProperty.call(t,e)},c.p="/";var i=window["webpackJsonp"]=window["webpackJsonp"]||[],u=i.push.bind(i);i.push=e,i=i.slice();for(var l=0;l<i.length;l++)e(i[l]);var s=u;a.push([0,"chunk-vendors"]),n()})({0:function(t,e,n){t.exports=n("cd49")},1:function(t,e){},cd49:function(t,e,n){"use strict";n.r(e);n("e260"),n("e6cf"),n("cca6"),n("a79d");var r=n("2b0e"),o=function(){var t=this,e=t.$createElement,n=t._self._c||e;return n("div",{attrs:{id:"app"}},[n("Home",{attrs:{msg:"Hello world!"}})],1)},a=[],c=n("bee2"),i=n("d4ec"),u=n("262e"),l=n("2caf"),s=n("9ab4"),p=n("1b40"),d=function(){var t=this,e=t.$createElement,n=t._self._c||e;return n("div",{staticClass:"home"},[n("h1",[t._v(t._s(t.msg))]),n("p",[t._v("Link data from API to Vue:")]),n("p",[t._v(t._s(t.data1))]),n("p",[t._v("Link data from SQL to Vue:")]),n("p",[t._v(t._s(t.data2))]),n("p",[t._v(t._s(t.data2.description))])])},f=[],h=(n("b0c0"),n("a4d3"),n("e01a"),Object(c["a"])((function t(){Object(i["a"])(this,t),this.id="",this.name=null,this.description=null,this.price=0}))),b=function(t){Object(u["a"])(n,t);var e=Object(l["a"])(n);function n(){var t;return Object(i["a"])(this,n),t=e.apply(this,arguments),t.data1="",t.data2=[],t.data3=new h,t.apiPath="https://localhost:7203",t}return Object(c["a"])(n,[{key:"created",value:function(){this.getFromController(),this.getFromController2()}},{key:"getFromController",value:function(){var t=this,e="".concat(this.apiPath,"/api/Products/GetProduct/");this.$http.get(e).then((function(e){t.data1=e.body}),(function(e){t.data1="error"}))}},{key:"getFromController2",value:function(){var t=this,e="".concat(this.apiPath,"/api/Products/GetSqlProduct/");this.$http.get(e).then((function(e){console.log(e.body),t.data2=e.body[0],t.data3=e.body[0]}),(function(e){t.data2="error"}))}}]),n}(p["c"]);Object(s["a"])([Object(p["b"])()],b.prototype,"msg",void 0),b=Object(s["a"])([p["a"]],b);var v=b,O=v,y=n("2877"),j=Object(y["a"])(O,d,f,!1,null,"42304c15",null),m=j.exports,g=function(t){Object(u["a"])(n,t);var e=Object(l["a"])(n);function n(){return Object(i["a"])(this,n),e.apply(this,arguments)}return Object(c["a"])(n)}(p["c"]);g=Object(s["a"])([Object(p["a"])({components:{Home:m}})],g);var _=g,P=_,w=Object(y["a"])(P,o,a,!1,null,null,null),k=w.exports,x=n("28dd");r["a"].use(x["a"]),r["a"].config.productionTip=!0,new r["a"]({render:function(t){return t(k)}}).$mount("#app")}});
//# sourceMappingURL=app.e98d36d0.js.map