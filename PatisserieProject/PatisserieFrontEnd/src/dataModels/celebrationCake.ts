import Flavour from "./flavour";
import Product from "./product";

export default class CelebrationCake extends Product {
    public tiers: number = 0;
    public flavourId: string = "";
    public flavour: Flavour = new Flavour();
    public icingFlavour: string = "";
}