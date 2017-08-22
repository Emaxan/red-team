import React from 'react';
import { Image } from 'react-bootstrap';
import { withGoogleMap, GoogleMap, Marker } from 'react-google-maps';
import withScriptjs from 'react-google-maps/lib/async/withScriptjs';
import { _ } from 'underscore';

import Titul from './images/titul.jpg';
import { GOOGLE_API_KEY } from '../../app/config';

import './AboutUs.scss';

const GOOGLE_MAP_ZOOM = 17;
const GOOGLE_MAP_COORDS_LAT = 53.888318;
const GOOGLE_MAP_COORDS_LNG = 27.544352;
const GOOGLE_MAP_SOURCE = `https://www.google.com/maps?q=${GOOGLE_MAP_COORDS_LAT}%2C${GOOGLE_MAP_COORDS_LNG}`;
const GOOGLE_MAP_API_URL = `https://maps.googleapis.com/maps/api/js?key=${GOOGLE_API_KEY}`;

const SimpleGoogleMap = withScriptjs(
  withGoogleMap(
    (props) => (
      <GoogleMap
        ref={props.onMapLoad}
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
    ),
  ),
);

const AboutUs = () => (
  <div>
    <Image className="about-us__img" src={Titul} />
    <h3>Address:
      <a href={GOOGLE_MAP_SOURCE} target="_blank">
        <address>Belarus, Minsk, Tolstoy str. 10</address>
      </a>
    </h3>
    <p>We are waiting for you with impatience. Have a good day.</p>
    <SimpleGoogleMap
      googleMapURL={GOOGLE_MAP_API_URL}
      loadingElement={
        <div>
          loading
        </div>
      }
      onMapLoad={_.noop}
      zoom={GOOGLE_MAP_ZOOM}
      center={
        {
          lat : GOOGLE_MAP_COORDS_LAT,
          lng : GOOGLE_MAP_COORDS_LNG,
        }
      }
      containerElement={
        <div className="about-us__map"/>
      }
      mapElement={
        <div  className="about-us__map"/>
      }
      markers={
        [
          {
            position : {
              lat : GOOGLE_MAP_COORDS_LAT,
              lng : GOOGLE_MAP_COORDS_LNG,
            },
          },
        ]
      }
    />
  </div>
);

export default AboutUs;
