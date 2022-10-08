//MIT License

//Copyright (c) 2022 Adita

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Adita.Wpf.Hosting
{
    /// <summary>
    /// Provides a mechanism for building Windows Presentation Foundation application.
    /// </summary>
    public interface IApplicationBuilder<TApp>
    {
        #region Properties
        /// <summary>
        /// Gets an <see cref="IServiceCollection"/> that used for building Windows Presentation Foundation application.
        /// </summary>
        IServiceCollection Services { get; }
        /// <summary>
        /// Gets a <see cref="Configuration"/> that used for building the Windows Presentation Foundation application.
        /// </summary>
        IConfiguration Configuration { get; }
        #endregion Properties

        #region Methods
        /// <summary>
        /// Sets up application configuration using specified <paramref name="configureAction"/>, This can be called multiple times and the results will be replaced.
        /// </summary>
        /// <param name="configureAction">An <see cref="Action{T}"/> of <see cref="IConfigurationBuilder"/> to sets up the application configuration
        /// that will be used to construct the application.</param>
        /// <returns>A current builder instance.</returns>
        IApplicationBuilder<TApp> ConfigureAppConfiguration(Action<IConfigurationBuilder> configureAction);
        /// <summary>
        /// Adds services to the container. This can be called multiple times and the results will be additive.
        /// </summary>
        /// <param name="configureAction">An <see cref="Action{T}"/> of <see cref="IServiceCollection"/> to add services
        /// that will be used to construct the application.</param>
        /// <returns>A current builder instance.</returns>
        IApplicationBuilder<TApp> ConfigureServices(Action<IServiceCollection> configureAction);
        /// <summary>
        /// Builds a Windows Presentation Foundation application.
        /// </summary>
        /// <returns>A Windows Presentation Foundation application.</returns>
        TApp Build();
        #endregion Methods

    }
}
