// *** WARNING: this file was generated by pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Myprovider
{
    /// <summary>
    /// Access tokens allow a user to authenticate against the Pulumi Service
    /// </summary>
    [MyproviderResourceType("myprovider:index:MyResource")]
    public partial class MyResource : global::Pulumi.CustomResource
    {
        /// <summary>
        /// Description of the access token.
        /// </summary>
        [Output("description")]
        public Output<string?> Description { get; private set; } = null!;


        /// <summary>
        /// Create a MyResource resource with the given unique name, arguments, and options.
        /// </summary>
        ///
        /// <param name="name">The unique name of the resource</param>
        /// <param name="args">The arguments used to populate this resource's properties</param>
        /// <param name="options">A bag of options that control this resource's behavior</param>
        public MyResource(string name, MyResourceArgs args, CustomResourceOptions? options = null)
            : base("myprovider:index:MyResource", name, args ?? new MyResourceArgs(), MakeResourceOptions(options, ""))
        {
        }

        private MyResource(string name, Input<string> id, CustomResourceOptions? options = null)
            : base("myprovider:index:MyResource", name, null, MakeResourceOptions(options, id))
        {
        }

        private static CustomResourceOptions MakeResourceOptions(CustomResourceOptions? options, Input<string>? id)
        {
            var defaultOptions = new CustomResourceOptions
            {
                Version = Utilities.Version,
            };
            var merged = CustomResourceOptions.Merge(defaultOptions, options);
            // Override the ID if one was specified for consistency with other language SDKs.
            merged.Id = id ?? merged.Id;
            return merged;
        }
        /// <summary>
        /// Get an existing MyResource resource's state with the given name, ID, and optional extra
        /// properties used to qualify the lookup.
        /// </summary>
        ///
        /// <param name="name">The unique name of the resulting resource.</param>
        /// <param name="id">The unique provider ID of the resource to lookup.</param>
        /// <param name="options">A bag of options that control this resource's behavior</param>
        public static MyResource Get(string name, Input<string> id, CustomResourceOptions? options = null)
        {
            return new MyResource(name, id, options);
        }
    }

    public sealed class MyResourceArgs : global::Pulumi.ResourceArgs
    {
        /// <summary>
        /// Description of the access token.
        /// </summary>
        [Input("description", required: true)]
        public Input<string> Description { get; set; } = null!;

        public MyResourceArgs()
        {
        }
        public static new MyResourceArgs Empty => new MyResourceArgs();
    }
}
