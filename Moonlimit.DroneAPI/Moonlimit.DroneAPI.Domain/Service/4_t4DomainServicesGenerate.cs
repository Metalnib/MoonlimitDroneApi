﻿


// —————————————— 
// <auto-generated> 
//	This code was auto-generated 01/03/2021 11:17:35
//     	T4 template generates service code
//	NOTE:T4 generated code may need additional updates/addjustments by developer in order to compile a solution.
// <auto-generated> 
// —————————————–
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using AutoMapper;
using Moonlimit.DroneAPI.Entity;
using Moonlimit.DroneAPI.Entity.UnitofWork;
using Moonlimit.DroneAPI.Entity.DroneCom;

namespace Moonlimit.DroneAPI.Domain.Service
{

    /// <summary>
    ///
    /// A ObjectDetection service
    ///       
    /// </summary>
    public class ObjectDetectionService<Tv, Te> : GenericService<Tv, Te>
                                        where Tv : ObjectDetectionViewModel
                                        where Te : ObjectDetection
    {
        //DI must be implemented in specific service as well beside GenericService constructor
        public ObjectDetectionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            if (_unitOfWork == null)
                _unitOfWork = unitOfWork;
            if (_mapper == null)
                _mapper = mapper;
        }
        //add here any custom service method or override generic service method
    }

	/// <summary>
    /// A ObjectDetection service
    /// </summary>
    public class ObjectDetectionServiceAsync<Tv, Te> : GenericServiceAsync<Tv, Te>
                                        where Tv : ObjectDetectionViewModel
                                        where Te : ObjectDetection
    {
        //DI must be implemented in specific service as well beside GenericService constructor
        public ObjectDetectionServiceAsync(IUnitOfWork unitOfWork, IMapper mapper)
        {
            if (_unitOfWork == null)
                _unitOfWork = unitOfWork;
            if (_mapper == null)
                _mapper = mapper;
        }
        //add here any custom service method or override generic service method
    }

    /// <summary>
    ///
    /// A PlannedRoute service
    ///       
    /// </summary>
    public class PlannedRouteService<Tv, Te> : GenericService<Tv, Te>
                                        where Tv : PlannedRouteViewModel
                                        where Te : PlannedRoute
    {
        //DI must be implemented in specific service as well beside GenericService constructor
        public PlannedRouteService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            if (_unitOfWork == null)
                _unitOfWork = unitOfWork;
            if (_mapper == null)
                _mapper = mapper;
        }
        //add here any custom service method or override generic service method
    }

	/// <summary>
    /// A PlannedRoute service
    /// </summary>
    public class PlannedRouteServiceAsync<Tv, Te> : GenericServiceAsync<Tv, Te>
                                        where Tv : PlannedRouteViewModel
                                        where Te : PlannedRoute
    {
        //DI must be implemented in specific service as well beside GenericService constructor
        public PlannedRouteServiceAsync(IUnitOfWork unitOfWork, IMapper mapper)
        {
            if (_unitOfWork == null)
                _unitOfWork = unitOfWork;
            if (_mapper == null)
                _mapper = mapper;
        }
        //add here any custom service method or override generic service method
    }

    /// <summary>
    ///
    /// A StatusReport service
    ///       
    /// </summary>
    public class StatusReportService<Tv, Te> : GenericService<Tv, Te>
                                        where Tv : StatusReportViewModel
                                        where Te : StatusReport
    {
        //DI must be implemented in specific service as well beside GenericService constructor
        public StatusReportService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            if (_unitOfWork == null)
                _unitOfWork = unitOfWork;
            if (_mapper == null)
                _mapper = mapper;
        }
        //add here any custom service method or override generic service method
    }

	/// <summary>
    /// A StatusReport service
    /// </summary>
    public class StatusReportServiceAsync<Tv, Te> : GenericServiceAsync<Tv, Te>
                                        where Tv : StatusReportViewModel
                                        where Te : StatusReport
    {
        //DI must be implemented in specific service as well beside GenericService constructor
        public StatusReportServiceAsync(IUnitOfWork unitOfWork, IMapper mapper)
        {
            if (_unitOfWork == null)
                _unitOfWork = unitOfWork;
            if (_mapper == null)
                _mapper = mapper;
        }
        //add here any custom service method or override generic service method
    }

    /// <summary>
    ///
    /// A DroneCommands service
    ///       
    /// </summary>
    public class DroneCommandsService<Tv, Te> : GenericService<Tv, Te>
                                        where Tv : DroneCommandsViewModel
                                        where Te : DroneCommands
    {
        //DI must be implemented in specific service as well beside GenericService constructor
        public DroneCommandsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            if (_unitOfWork == null)
                _unitOfWork = unitOfWork;
            if (_mapper == null)
                _mapper = mapper;
        }
        //add here any custom service method or override generic service method
    }

	/// <summary>
    /// A DroneCommands service
    /// </summary>
    public class DroneCommandsServiceAsync<Tv, Te> : GenericServiceAsync<Tv, Te>
                                        where Tv : DroneCommandsViewModel
                                        where Te : DroneCommands
    {
        //DI must be implemented in specific service as well beside GenericService constructor
        public DroneCommandsServiceAsync(IUnitOfWork unitOfWork, IMapper mapper)
        {
            if (_unitOfWork == null)
                _unitOfWork = unitOfWork;
            if (_mapper == null)
                _mapper = mapper;
        }
        //add here any custom service method or override generic service method
    }

    /// <summary>
    ///
    /// A DroneOnvifSettings service
    ///       
    /// </summary>
    public class DroneOnvifSettingsService<Tv, Te> : GenericService<Tv, Te>
                                        where Tv : DroneOnvifSettingsViewModel
                                        where Te : DroneOnvifSettings
    {
        //DI must be implemented in specific service as well beside GenericService constructor
        public DroneOnvifSettingsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            if (_unitOfWork == null)
                _unitOfWork = unitOfWork;
            if (_mapper == null)
                _mapper = mapper;
        }
        //add here any custom service method or override generic service method
    }

	/// <summary>
    /// A DroneOnvifSettings service
    /// </summary>
    public class DroneOnvifSettingsServiceAsync<Tv, Te> : GenericServiceAsync<Tv, Te>
                                        where Tv : DroneOnvifSettingsViewModel
                                        where Te : DroneOnvifSettings
    {
        //DI must be implemented in specific service as well beside GenericService constructor
        public DroneOnvifSettingsServiceAsync(IUnitOfWork unitOfWork, IMapper mapper)
        {
            if (_unitOfWork == null)
                _unitOfWork = unitOfWork;
            if (_mapper == null)
                _mapper = mapper;
        }
        //add here any custom service method or override generic service method
    }

    /// <summary>
    ///
    /// A GeoArea service
    ///       
    /// </summary>
    public class GeoAreaService<Tv, Te> : GenericService<Tv, Te>
                                        where Tv : GeoAreaViewModel
                                        where Te : GeoArea
    {
        //DI must be implemented in specific service as well beside GenericService constructor
        public GeoAreaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            if (_unitOfWork == null)
                _unitOfWork = unitOfWork;
            if (_mapper == null)
                _mapper = mapper;
        }
        //add here any custom service method or override generic service method
    }

	/// <summary>
    /// A GeoArea service
    /// </summary>
    public class GeoAreaServiceAsync<Tv, Te> : GenericServiceAsync<Tv, Te>
                                        where Tv : GeoAreaViewModel
                                        where Te : GeoArea
    {
        //DI must be implemented in specific service as well beside GenericService constructor
        public GeoAreaServiceAsync(IUnitOfWork unitOfWork, IMapper mapper)
        {
            if (_unitOfWork == null)
                _unitOfWork = unitOfWork;
            if (_mapper == null)
                _mapper = mapper;
        }
        //add here any custom service method or override generic service method
    }

    /// <summary>
    ///
    /// A GeoPoint service
    ///       
    /// </summary>
    public class GeoPointService<Tv, Te> : GenericService<Tv, Te>
                                        where Tv : GeoPointViewModel
                                        where Te : GeoPoint
    {
        //DI must be implemented in specific service as well beside GenericService constructor
        public GeoPointService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            if (_unitOfWork == null)
                _unitOfWork = unitOfWork;
            if (_mapper == null)
                _mapper = mapper;
        }
        //add here any custom service method or override generic service method
    }

	/// <summary>
    /// A GeoPoint service
    /// </summary>
    public class GeoPointServiceAsync<Tv, Te> : GenericServiceAsync<Tv, Te>
                                        where Tv : GeoPointViewModel
                                        where Te : GeoPoint
    {
        //DI must be implemented in specific service as well beside GenericService constructor
        public GeoPointServiceAsync(IUnitOfWork unitOfWork, IMapper mapper)
        {
            if (_unitOfWork == null)
                _unitOfWork = unitOfWork;
            if (_mapper == null)
                _mapper = mapper;
        }
        //add here any custom service method or override generic service method
    }

    /// <summary>
    ///
    /// A PatrolConfig service
    ///       
    /// </summary>
    public class PatrolConfigService<Tv, Te> : GenericService<Tv, Te>
                                        where Tv : PatrolConfigViewModel
                                        where Te : PatrolConfig
    {
        //DI must be implemented in specific service as well beside GenericService constructor
        public PatrolConfigService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            if (_unitOfWork == null)
                _unitOfWork = unitOfWork;
            if (_mapper == null)
                _mapper = mapper;
        }
        //add here any custom service method or override generic service method
    }

	/// <summary>
    /// A PatrolConfig service
    /// </summary>
    public class PatrolConfigServiceAsync<Tv, Te> : GenericServiceAsync<Tv, Te>
                                        where Tv : PatrolConfigViewModel
                                        where Te : PatrolConfig
    {
        //DI must be implemented in specific service as well beside GenericService constructor
        public PatrolConfigServiceAsync(IUnitOfWork unitOfWork, IMapper mapper)
        {
            if (_unitOfWork == null)
                _unitOfWork = unitOfWork;
            if (_mapper == null)
                _mapper = mapper;
        }
        //add here any custom service method or override generic service method
    }
}