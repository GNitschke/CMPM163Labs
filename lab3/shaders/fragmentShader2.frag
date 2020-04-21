uniform vec3 colorA;
uniform vec3 colorB;
uniform vec3 colorC;
uniform vec3 colorD;
varying vec3 vUv;

void main() {
 	gl_FragColor = vec4(mix(mix(colorD, colorC, vUv.x), mix(colorA,colorB, vUv.y), vUv.z), 1.0);
}
