using System;
using System.Collections.Generic;
using System.Text;

namespace CovidApps.contract.Map
{

    public interface IView
    {
        void onGetCurrentLocationSuccess(LocationInfo locationInfo);
    }
    public interface IModel
    {
        void getCurrentLocation(IOnListerner listerner);
    }

    public interface IPresenter
    {
        void getCurrentLocation();
    }
    public interface IOnListerner
    {
        void onGetCurrentLocationSuccess(LocationInfo locationInfo);
    }
}
