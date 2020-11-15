using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using FinanceServ.Common;

namespace FinanceServ
{
    /// <summary>
    /// ������������ ����������
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// �������������� ����� ��������� ������ <see cref="Startup"/>
        /// </summary>
        /// <param name="configuration">������������.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// ������������.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// ����� ���������� ������ ����������. ������������ ��� ����������� �������� � IoC ����������.
        /// </summary>
        /// <param name="services">��������� ��������.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.ConfigureSwagger();
        }

        /// <summary>
        /// M���� ���������� ������ ����������. ������������ ��� ������������ ��������� ��� ��������� HTTP-�������.
        /// </summary>
        /// <param name="app">�������� ������������ ����������.</param>
        /// <param name="env">���������� �� ���������, � ������� �������� ����������.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCors();

            app.UseOpenApi();

            app.UseSwaggerUi3();
        }
    }
}
