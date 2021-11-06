using System;
using System.Collections.Generic;
using System.Text;

namespace CovidApps.contract.Map
{

    public interface IView
    {
        void onGetCurrentLocationSuccess(LocationInfo locationInfo);
        void OnFailure(string error);
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
         void OnFailure(string error);
    }
}
