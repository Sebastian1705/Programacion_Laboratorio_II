﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ArchiveroFisico : Almacenador, IAlmacenable<string, Archivo>
    {
        #region Fields

        private string pathArchivos;

        #endregion

        #region Propieties

        public string PathArchivos
        {
            get
            {
                return this.pathArchivos;
            }
            set
            {
                this.pathArchivos = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Crear un constructor que reciba y asigne el/los atributos de la misma.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="capacidad"></param>
        public ArchiveroFisico(string path, int capacidad)
            : base(capacidad)
        {
            this.Capacidad = capacidad;
        }

        /// <summary>
        /// El método MostrarArchivos lanzará una excepción del tipo NotImplementedException.
        /// </summary>
        public override void MostrarArchivos()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// El método Guardar deberá guardar un objeto de tipo archivo en un archivo de texto en la ubicación definida en el atributo pathArchivos.
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public bool Guardar(Archivo elemento)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path += @"\" + elemento.Nombre;
            StreamWriter sw = new StreamWriter(path, File.Exists(path));
            try
            {
                sw.WriteLine(elemento.Contenido);
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                sw.Close();
            }
            return true;
        }

        /// <summary>
        /// El método Leer recibirá el nombre de un archivo y deberá retornar su contenido.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string Leer(string path)
        {
            string retorno = null;
            StreamReader sr = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + path);
            if (File.Exists(path))
            {
                try
                {
                    if(!(sr is null))
                        retorno = sr.ReadToEnd();
                }
                catch(Exception e)
                {
                    throw e;
                }
                finally
                {
                    sr.Close();
                }
            }
            return retorno;
        }

        #endregion
    }
}
