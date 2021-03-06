AutoPilot
=========

.. class:: AutoPilot

   Provides basic auto-piloting utilities for a vessel. Created by calling
   :attr:`Vessel.AutoPilot`.

   .. method:: SetRotation (pitch, heading, [roll = NaN], [referenceFrame = Vessel.SurfaceReferenceFrame], [wait = false])

      Points the vessel in the specified direction, and holds it there. Setting
      the roll angle is optional.

      If wait is ``false`` (the default) this method returns immediately, and
      the auto-pilot continues to rotate the vessel. If wait is ``true``, this
      method returns when the auto-pilot has rotated the vessel into the
      requested orientation.

      The auto-pilot is disengaged either when :meth:`AutoPilot.Disengage` is
      called, or when the client that requested the auto-pilot command
      disconnects.

      :param double pitch: The desired pitch above/below the horizon, in
                           degrees. A value between -90° and +90° degrees.
      :param double heading: The desired heading in degrees. A valud between 0°
                             and 360°.
      :param double roll: Optional desired roll angle relative to the horizon,
                          in degrees. A value between -180° and +180°.
      :param ReferenceFrame referenceFrame: The reference frame that the pitch,
                                            heading and roll are in. Defaults to
                                            the vessels surface reference frame.
      :param bool wait: If true, this method returns when the auto-pilot has
                        rotated the vessel into the requested orientation.

   .. method:: SetDirection (direction, [roll = NaN], [referenceFrame = Vessel.SurfaceReferenceFrame], [wait = false])

      Points the vessel along the specified direction vector, and holds it
      there. Setting the roll angle is optional.

      If wait is ``false`` (the default) this method returns immediately, and
      the auto-pilot continues to rotate the vessel. If wait is ``true``, this
      method returns when the auto-pilot has rotated the vessel into the
      requested orientation.

      The auto-pilot is disengaged either when :meth:`AutoPilot.Disengage` is
      called, or when the client that requested the auto-pilot command
      disconnects.

      :param Vector3 direction: The desired direction (pitch and heading) as a
                               unit vector.
      :param double roll: Optional desired roll angle relative to the horizon,
                          in degrees. A value between -180° and 180°.
      :param ReferenceFrame referenceFrame: The reference frame that the
                                            direction vector is in. Defaults to
                                            the vessels surface reference frame.
      :param bool wait: If true, this method returns when the auto-pilot has
                        rotated the vessel into the requested orientation.

   .. attribute:: Error

      Gets the error, in degrees, between the direction the ship has been asked
      to point in and the actual direction it is pointing in. If the auto-pilot
      has not been engaged, returns zero.

      :rtype: double

   .. attribute:: RollError

      Gets the error, in degrees, between the roll the ship has been asked to be
      in and the actual roll. If the auto-pilot has not been engaged, returns
      zero.

      :rtype: double

   .. method:: Disengage ()

      Disengage the auto-pilot.  Has no effect unless
      :meth:`AutoPilot.SetRotation` or :meth:`AutoPilot.SetDirection` have been
      called previously.

      .. note:: This will disable :attr:`Control.SAS`.
