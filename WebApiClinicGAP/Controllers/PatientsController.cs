﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiClinicGAP.Models;

namespace WebApiClinicGAP.Controllers
{
    public class PatientsController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/Patients
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IQueryable<Patients> GetPatients()
        {
            return db.Patients;
        }

        // GET: api/Patients/5
        [ResponseType(typeof(Patients))]
        public IHttpActionResult GetPatients(int id)
        {
            Patients patients = db.Patients.Find(id);
            if (patients == null)
            {
                return NotFound();
            }

            return Ok(patients);
        }

        public string GetPatientName(int id)
        {
            Patients patients = db.Patients.Find(id);
            if (patients == null)
            {
                return null;
            }

            return patients.patientName;
        }

        // PUT: api/Patients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPatients(int id, Patients patients)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (id != patients.idPatient)
            {
                return BadRequest();
            }

            db.Entry(patients).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Patients
        [ResponseType(typeof(Patients))]
        public IHttpActionResult PostPatients(Patients patients)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            // Existing patient validation
            Patients _patient = db.Patients.Where(p => p.idPatient == patients.idPatient).FirstOrDefault();
            if (_patient != null)
            {
                return BadRequest();
            }

            db.Patients.Add(patients);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = patients.idPatient }, patients);
        }

        // DELETE: api/Patients/5
        [ResponseType(typeof(Patients))]
        public IHttpActionResult DeletePatients(int id)
        {
            Patients patients = db.Patients.Find(id);
            if (patients == null)
            {
                return NotFound();
            }

            db.Patients.Remove(patients);
            db.SaveChanges();

            return Ok(patients);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PatientsExists(int id)
        {
            return db.Patients.Count(e => e.idPatient == id) > 0;
        }
    }
}