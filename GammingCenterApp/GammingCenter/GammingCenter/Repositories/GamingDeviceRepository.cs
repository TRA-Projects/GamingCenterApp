

using Microsoft.EntityFrameworkCore;
﻿using Microsoft.EntityFrameworkCore;

namespace GammingCenter.Repositories
{
    public class GamingDeviceRepository
    {
        //Allow Repo to access Db context
        private readonly GammingCenterContext Context;

        public GamingDeviceRepository(GammingCenterContext _Context)
        {
            Context = _Context;
        }

        ////////////////////////////////////////////////////////////////////


        // 1-Add Device Method

        public void AddGamingDevice(GamingDevice device)
        {

            Context.GamingDevices.Add(device);
            Context.SaveChanges();
        }

        ////////////////////////////////////////////////////////////////////


        // 2-update Device Method

        public void UpdateGamingDevice(GamingDevice device)
        {
            Context.GamingDevices.Update(device);
            Context.SaveChanges();
        }

        ////////////////////////////////////////////////////////////////////


        // 3-Delete Device Method

        public void DeleteGamingDevice(GamingDevice device)
        {
            Context.GamingDevices.Remove(device);
            Context.SaveChanges();
        }

        ////////////////////////////////////////////////////////////////////


        // 4-Search Device Method
        public GamingDevice SearchGamingDevice(int DeviceId)
        {
            return
                Context.GamingDevices.FirstOrDefault(d => d.DeviceID == DeviceId);
        }

        ////////////////////////////////////////////////////////////////////



        // 5-View Available Device Method
        public List<GamingDevice> GetAvailableDevice()
        {
            return
               Context.GamingDevices.Where(d => d.Status == "Available").ToList();
        }

        ////////////////////////////////////////////////////////////////////


        // 6-change Device Status Method
        public void changeDeviceStatus(int DeviceId, string Status)
        {

            var device = Context.GamingDevices.FirstOrDefault(d => d.DeviceID == DeviceId);

            if (device != null)
            {
                device.Status = Status;
                Context.SaveChanges();
            }
        }
    }
  
}
