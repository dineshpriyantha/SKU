﻿using SKU.Model;

namespace SKU.Services
{
    public interface IShelfManager
    {
        Task<List<LaneWithSkuViewModel>> GetShelfCabinets();
    }
}
