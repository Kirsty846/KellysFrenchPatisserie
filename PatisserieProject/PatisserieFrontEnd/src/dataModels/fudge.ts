import Flavour from "./flavour";
import Product from "./product";

export default class Fudge extends Product {
    public size: number = 0;
    public flavourId: string = "";
    public flavour: Flavour = new Flavour();
}