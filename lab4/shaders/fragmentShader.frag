uniform vec3 colorA;
uniform vec3 colorB;
varying vec2 vUv;

void main() {
  gl_FragColor = vec4(vUv.x, vUv.y, 0.0, 1.0);
}
