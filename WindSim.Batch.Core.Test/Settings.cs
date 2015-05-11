//------------------------------------------------------------------------------
// Copyright (c) 2012, 2013, 2014, 2015 Francesco Paraggio.
// 
// Author: Francesco Paraggio fparaggio@gmail.com
// 
// This file is part of WindSimBattery
// 
// WindSimBattery is free software: you can redistribute it and/or modify it under the terms of the GNU Affero General Public License as published by the Free Software Foundation; either version 3 of the License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Affero General Public License for more details.
// 
// You should have received a copy of the GNU Affero General Public License along with this program. If not, see http://www.gnu.org/licenses/.
// 
// The usage of a range of years within a copyright statement contained within this distribution should be interpreted as being equivalent to a list of years including the first and last year specified and all consecutive years between them. For example, a copyright statement that reads 'Copyright (c) 2005, 2007- 2009, 2011-2012' should be interpreted as being identical to a statement that reads 'Copyright (c) 2005, 2007, 2008, 2009, 2011, 2012' and a copyright statement that reads "Copyright (c) 2005-2012' should be interpreted as being identical to a statement that reads 'Copyright (c) 2005, 2006, 2007, 2008, 2009, 2010, 2011, 2012'."
//------------------------------------------------------------------------------

namespace WindSim.Batch.Core.Test.Properties {
    
    
    // La classe consente la gestione di eventi specifici sulla classe delle impostazioni:
    //  L'evento SettingChanging viene generato prima della modifica di un valore dell'impostazione.
    //  L'evento PropertyChanged viene generato dopo la modifica di un valore dell'impostazione.
    //  L'evento SettingsLoaded viene generato dopo il caricamento dei valori dell'impostazione.
    //  L'evento SettingsSaving viene generato prima del salvataggio dei valori dell'impostazione.
    internal sealed partial class Settings {
        
        public Settings() {
            // // Per aggiungere gestori eventi per il salvataggio e la modifica delle impostazioni, rimuovere i commenti dalle righe seguenti:
            //
            // this.SettingChanging += this.SettingChangingEventHandler;
            //
            // this.SettingsSaving += this.SettingsSavingEventHandler;
            //
        }
        
        private void SettingChangingEventHandler(object sender, System.Configuration.SettingChangingEventArgs e) {
            // Aggiungere qui il codice per gestire l'evento SettingChangingEvent.
        }
        
        private void SettingsSavingEventHandler(object sender, System.ComponentModel.CancelEventArgs e) {
            // Aggiungere qui il codice per gestire l'evento SettingsSaving.
        }
    }
}
