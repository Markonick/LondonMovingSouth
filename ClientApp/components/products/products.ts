import Vue from 'vue';
import { Component } from 'vue-property-decorator';

interface IProduct {
    dateFormatted: string;
    name: number;
    summary: string;
    price: number;
}

@Component
export default class ProductComponent extends Vue {
    products: IProduct[] = [];

    mounted() {
        fetch('api/Products')
            .then(response => response.json() as Promise<IProduct[]>)
            .then(data => {
                this.products = data;
            });
    }
}
