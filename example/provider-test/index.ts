import * as pulumi from "@pulumi/pulumi";
import * as myprovider from "@pulumi/myprovider";

const resource = new myprovider.MyResource("test", {
    description: "this is my resource2"
});