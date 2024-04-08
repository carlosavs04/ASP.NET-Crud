class Footer extends HTMLElement {
    constructor() {
        super();
        this.innerHTML = `
        <footer class="main-footer">
            <div class="float-right d-none d-sm-inline">
                Carlos Alberto Avalos Soto
            </div>
            <strong>Copyright &copy; 2014-2021 <a href="https://utt.edu.mx/">Universidad Tecnológica de Torreón</a>.</strong> All rights reserved.
        </footer>
        `;
    }
}

if ('customElements' in window) {
    customElements.define('main-footer', Footer);
}