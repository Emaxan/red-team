import React from 'react';
import { Image } from 'react-bootstrap';
import { withGoogleMap, GoogleMap, Marker } from 'react-google-maps';

import Titul from './images/titul.jpg';
import {
  GOOGLE_MAP_ZOOM,
  GOOGLE_MAP_COORDS_LAT,
  GOOGLE_MAP_COORDS_LNG,
  GOOGLE_MAP_SOURCE,
} from './constants';

import './AboutUsTab.scss';

export const SimpleGoogleMap = withGoogleMap((props) => (
  <GoogleMap
    defaultZoom={props.zoom}
    defaultCenter={props.center}
  >
    {
      props.markers.map((marker, index) => (
        <Marker
          key={index}
          position={marker.position}
          onClick={() => props.onMarkerClick(marker)}
        />
      ))
    }
  </GoogleMap>
));

function AboutUsTab() {
  return (
    <div>
      <Image className="about-us-tab__img" src={Titul} />
      <h3>Address:
        <a href={GOOGLE_MAP_SOURCE} target="_blank">
          <address>Belarus, Minsk, Tolstoy str. 10</address>
        </a>
      </h3>
      <p>We are waiting for you with impatience. Have a good day.</p>
      <SimpleGoogleMap
        zoom={GOOGLE_MAP_ZOOM}
        center={
          {
            lat : GOOGLE_MAP_COORDS_LAT,
            lng : GOOGLE_MAP_COORDS_LNG,
          }
        }
        containerElement={
          <div className="about-us-tab__map"/>
        }
        mapElement={
          <div  className="about-us-tab__map"/>
        }
        markers={[
          {
            position : new google.maps.LatLng(GOOGLE_MAP_COORDS_LAT, GOOGLE_MAP_COORDS_LNG), // eslint-disable-line
          },
        ]}
      />
    </div>
  );
}

export default AboutUsTab;
